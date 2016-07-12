using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentTracker.Core.Entities.Torrent;

namespace TorrentTracker.Core.Interface.ExternalServices
{
    public interface ITorrentService
    {
        string Login(string username, string password);

        Task<IEnumerable<Torrent>> GetAllTorrents(string label, string sortBy, bool descending, int limit, int offset);

        void AddTorrent(Torrent torrent);

        void DeleteTorrent(string hash);

        void ChangePriority(string hash);

        Task<TorrentDetails> GetTorrentDetails(string hash);

        Task<IEnumerable<TorrentContent>> GetTorrentContents(string hash);
    }
}
