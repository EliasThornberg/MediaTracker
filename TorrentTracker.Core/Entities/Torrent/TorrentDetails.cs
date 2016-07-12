namespace TorrentTracker.Core.Entities.Torrent
{
    public class TorrentDetails
    {
        public string SavePath { get; set; }

        public long Uploaded { get; set; }

        public long Downloaded { get; set; }
    }
}
