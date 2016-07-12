using System.Threading.Tasks;
using System.Web.Http;
using TorrentTracker.Core.Interface.ExternalServices;

namespace TorrentTrackerAPI.Controllers
{
    public class ShowsController : ApiController
    {
        private readonly IMovieService _movieservice;
        public ShowsController(IMovieService movieservice)
        {
            _movieservice = movieservice;
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
    }
}
