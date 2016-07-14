using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TorrentTracker.Core.Commands;
using TorrentTracker.Core.Entities.Media;
using TorrentTracker.Core.Interface.CQRS;
using TorrentTracker.Core.Interface.ExternalServices;

namespace TorrentTrackerAPI.Controllers
{
    public class ShowsController : ApiController
    {
        private readonly IMovieService _movieservice;
        private readonly IAsyncCommandHandler<ScanShows, IEnumerable<Show>> _handler;
        public ShowsController(IMovieService movieservice, IAsyncCommandHandler<ScanShows, IEnumerable<Show>> handler)
        {
            _movieservice = movieservice;
            _handler = handler;
        }

        public IHttpActionResult Get()
        {
            return Ok();
        }

        public IHttpActionResult Get(int showId)
        {
            return Ok();
        }

        [Route("Shows/{imdbId}")]
        public async Task<IHttpActionResult> GetByImdbId(string imdbId)
        {
            return Ok(await _movieservice.GetShowById(imdbId));
        }

        [Route("Shows/{searchText?}")]
        [HttpGet]
        public async Task<IHttpActionResult> SearchShow(string searchText)
        {
            return Ok(await _movieservice.SearchShow(searchText, true));
        }

        [Route("Shows/Scan")]
        public async Task<IHttpActionResult> ScanFolderForShows(List<string> foldersToScan)
        {
            ScanShows scanShows = new ScanShows()
            {
                FoldersToScan = foldersToScan
            };

            return Ok(await _handler.Handle(scanShows));
        }
    }
}
