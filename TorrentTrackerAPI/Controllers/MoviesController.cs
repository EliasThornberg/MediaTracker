using System.Threading.Tasks;
using System.Web.Http;
using TorrentTracker.Core.Interface.ExternalServices;
using TorrentTrackerAPI.ActionsResults;

namespace TorrentTrackerAPI.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly IMovieService _service;
        public MoviesController(IMovieService movieService)
        {
            _service = movieService;
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
    }
}
