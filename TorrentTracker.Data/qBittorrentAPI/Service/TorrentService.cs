using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using TorrentTracker.Core.Entities.Torrent;
using TorrentTracker.Core.Interface.ExternalServices;
using TorrentTracker.Data.qBittorrentAPI.Client;
using TorrentTracker.Data.qBittorrentAPI.Models;

namespace TorrentTracker.Data.qBittorrentAPI
{
    public class TorrentService : ITorrentService
    {
        private readonly IqBittorrentClient _client;

        public TorrentService(IqBittorrentClient client)
        {
            _client = client;
        }

        public void AddTorrent(Torrent torrent)
        {
            throw new NotImplementedException();
        }

        public void ChangePriority(string hash)
        {
            throw new NotImplementedException();
        }

        public void DeleteTorrent(string hash)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Torrent>> GetAllTorrents(string label, string sortBy, bool descending, int limit, int offset)
        {
            var parameters = new NameValueCollection()
            {
                {"label", label },
                {"sort", sortBy },
                {"reverse", descending.ToString()},
                {"limit", limit.ToString() },
                {"offset", offset.ToString() }

            };

            var torrents = await _client.Get<IEnumerable<qBittorrent>>("admin", "8tfunqBessie", parameters, "/query/torrents");

            List<Torrent> torrentList = new List<Torrent>();
            foreach(var t in torrents)
            {
                Torrent torrent = new Torrent();
                torrent.Title = t.Name;
                torrent.TorrentHash = t.Hash;
                torrent.Uploadspeed = t.Upspeed;
                torrent.Downloadspeed = t.Dlspeed;
                torrent.Progress = t.Progress;
                torrent.Size = t.Size;
                torrent.Label = t.Label;
                torrent.ETAInSeconds = t.Eta;

                torrentList.Add(torrent);
            }

            return torrentList;
        }

        public async Task<IEnumerable<TorrentContent>> GetTorrentContents(string hash)
        {
            var torrentContents = await _client.Get<IEnumerable<qBittorrentContent>>("admin", "8tfunqBessie", null, "/query/propertiesFiles/" + hash);

            List<TorrentContent> contentList = new List<TorrentContent>();
            foreach(var torrentContent in torrentContents)
            {
                TorrentContent content = new TorrentContent();
                content.Name = torrentContent.Name;
                content.Progress = torrentContent.Progress;
                content.Size = torrentContent.Size;
                content.Seeding = torrentContent.Is_seed;

                contentList.Add(content);
            }

            return contentList;
        }

        public async Task<TorrentDetails> GetTorrentDetails(string hash)
        {
            var torrentDetails = await _client.Get<qBittorrentDetails>("admin", "8tfunqBessie", null, "/query/propertiesGeneral/" + hash);

            TorrentDetails details = new TorrentDetails();
            details.Downloaded = torrentDetails.Total_downloaded;
            details.Uploaded = torrentDetails.Total_uploaded;
            details.SavePath = torrentDetails.Save_path;

            return details;
        }

        public string Login(string username, string password)
        {
            return _client.Login(username, password).Result;
        }
    }
}
