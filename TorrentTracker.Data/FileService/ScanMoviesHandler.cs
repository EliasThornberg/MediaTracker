using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorrentTracker.Core.Commands;
using TorrentTracker.Core.Entities.Media;
using TorrentTracker.Core.Interface.ApplicationService;
using TorrentTracker.Core.Interface.CQRS;
using TorrentTracker.Core.Interface.ExternalServices;

namespace TorrentTracker.Data.FileService
{
    public class ScanMoviesHandler : IAsyncCommandHandler<ScanMovies, IEnumerable<Movie>>
    {
        private readonly IMediaFileService<MediaInfo> _fileService;
        private readonly IMovieService _omdbService;

        public ScanMoviesHandler(IMediaFileService<MediaInfo> fileService, IMovieService omdbService)
        {
            _fileService = fileService;
            _omdbService = omdbService;
        }

        public async Task<IEnumerable<Movie>> Handle(ScanMovies query)
        {
            var result = _fileService.GetMediaFiles(query.FoldersToScan.ToArray()).Take(5).Skip(0);

            List<Movie> movies = new List<Movie>();
            foreach(var mediaInfo in result)
            {
                var searchResult = await _omdbService.SearchMovie(mediaInfo.Title, true);
                foreach(var searchHit in searchResult)
                {
                    if(searchHit.Title == mediaInfo.Title)
                    {
                        Movie movie = new Movie(searchHit.Title, searchHit.Description);
                        movie.PosterImagePath = searchHit.PosterImagePath;
                        movie.BorderImagePath = searchHit.BorderImagePath;
                        movies.Add(movie);
                    }
                }
            }

            return movies;
        }
    }
}
