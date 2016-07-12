using System.Collections.Specialized;
using System.Threading.Tasks;

namespace TorrentTracker.Data.qBittorrentAPI.Client
{
    public interface IqBittorrentClient
    {
        Task<string> Login(string username, string password);

        Task<T> Get<T>(string username, string password, NameValueCollection collection, string endpoint);
    }
}
