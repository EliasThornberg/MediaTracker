using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TorrentTracker.Core.Commands;
using TorrentTracker.Core.Entities.Media;
using TorrentTracker.Core.Interface.CQRS;
using TorrentTracker.Core.Interface.ExternalServices;

namespace TorrentTrackerAPI.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly IMovieService _service;
        IAsyncCommandHandler<ScanMovies, IEnumerable<Movie>> _handler;
        public MoviesController(IMovieService movieService, IAsyncCommandHandler<ScanMovies, IEnumerable<Movie>> handler)
        {
            _service = movieService;
            _handler = handler;
        }

        public IHttpActionResult Get()
        {
            return Ok();
        }

        public IHttpActionResult Get(int movieId)
        {
            return Ok();
        }

        [Route("Movies/{searchText}")]
        [HttpGet]
        public async Task<IHttpActionResult> SearchMovie(string searchText)
        {
            return Ok(await _service.SearchMovie(searchText, true));
        }

        [Route("Movies/Scan")]
        [HttpGet]
        public async Task<IHttpActionResult> ScanFolderForMovies([FromUri]List<string> foldersToScan)
        {
            ScanMovies scanMovies = new ScanMovies()
            {
                FoldersToScan = foldersToScan
            };

            return Ok(await _handler.Handle(scanMovies));
        }
    }
}
