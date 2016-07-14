using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorrentTracker.Core.Commands;
using TorrentTracker.Core.Entities.Media;
using TorrentTracker.Core.Interface.ApplicationService;
using TorrentTracker.Core.Interface.Cache;
using TorrentTracker.Core.Interface.CQRS;
using TorrentTracker.Core.Interface.ExternalServices;
using TorrentTracker.Data.StringApproximation;

namespace TorrentTracker.Data.FileService
{
    public class ScanShowsHandler : IAsyncCommandHandler<ScanShows, IEnumerable<Show>>
    {
        private readonly IMediaFileService<MediaInfo> _fileService;
        private readonly IMovieService _tmdbService;
        private readonly IStringApproximationFactory _approximationFactory;
        private readonly ICache _cache;

        public ScanShowsHandler(IMediaFileService<MediaInfo> fileService, IMovieService tmdbService, IStringApproximationFactory approximationFactory, ICache cache)
        {
            _fileService = fileService;
            _tmdbService = tmdbService;
            _approximationFactory = approximationFactory;
            _cache = cache;
        }

        public async Task<IEnumerable<Show>> Handle(ScanShows query)
        {
            var result = _fileService.GetMediaFiles(query.FoldersToScan.ToArray()).Take(5).Skip(0);
            List<Show> shows = new List<Show>();
            foreach (var mediaInfo in result)
            {
                var show = _cache.GetValue<Show>(mediaInfo.Title) ?? await SearchShowInformation(mediaInfo.Title);
                if (show == null)
                    continue;
            }

            return shows;
        }

        private async Task<Show> SearchShowInformation(string filename)
        {
            var approximationMethods = _approximationFactory.Create(ApproximationMethod.LevenshteinsDistance);
            var searchResult = await _tmdbService.SearchShow(filename, true);

            foreach (var searchHit in searchResult)
            {
                if (approximationMethods.GetSimilarity(filename, searchHit.Title) > 0.6)
                {
                    Show show = new Show(searchHit.Title, searchHit.Description);
                    show.PosterImagePath = searchHit.PosterImagePath;
                    show.BorderImagePath = searchHit.BorderImagePath;
                    _cache.SetValue(show, filename, DateTimeOffset.Now.AddMinutes(20));

                    return show;
                }
            }

            return null;
        }
    }
}
