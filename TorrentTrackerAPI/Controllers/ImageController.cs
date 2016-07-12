using System.Threading.Tasks;
using System.Web.Http;
using TorrentTracker.Core.Interface.ExternalServices;
using TorrentTrackerAPI.ActionsResults;

namespace TorrentTrackerAPI.Controllers
{
    public class ImageController : ApiController
    {
        private readonly IMovieService _service;
        public ImageController(IMovieService service)
        {
            _service = service;
        }

        [Route("Poster/{posterPath?}")]
        public async Task<IHttpActionResult> GetPoster(string posterPath)
        {
            return new FileResult(await _service.GetPoster(posterPath), "test.jpg");
        }
    }
}
