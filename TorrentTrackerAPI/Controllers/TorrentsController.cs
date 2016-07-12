using System.Threading.Tasks;
using System.Web.Http;
using TorrentTracker.Core.Interface.ExternalServices;

namespace TorrentTrackerAPI.Controllers
{
    public class TorrentsController : ApiController
    {
        private readonly ITorrentService _torrentService;

        public TorrentsController(ITorrentService service)
        { 
            _torrentService = service;
        }

        [Route("Torrents/")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _torrentService.GetAllTorrents(null, null, true, 100, 0));
        }

        [Route("Torrents/{hash}/Details")]
        public async Task<IHttpActionResult> GetDetails(string hash)
        {
            return Ok(await _torrentService.GetTorrentDetails(hash));
        }

        [Route("Torrents/{hash}/Contents")]
        public async Task<IHttpActionResult> GetContents(string hash)
        {
            return Ok(await _torrentService.GetTorrentContents(hash));
        }

        [Route("Torrents/Login/")]
        public IHttpActionResult Post(string username, string password)
        {
            var result = _torrentService.Login(username, password);

            return Ok(result);
        }
    }
}
