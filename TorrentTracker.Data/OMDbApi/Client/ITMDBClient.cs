using System.Collections.Specialized;
using System.IO;
using System.Threading.Tasks;

namespace TorrentTracker.Data.OMDbApi.Client
{
    public interface ITMDBClient
    {
        Task<T> Get<T>(NameValueCollection parameters, string endpoint, bool includedBaseAdress = false);

        Task<byte[]> GetFile(NameValueCollection parameters, string endpoint, bool includedBaseAdress = false);
    }
}
