namespace TorrentTracker.Core.Entities.Torrent
{
    public class TorrentContent
    {
        public string Name { get; set; }

        public long Size { get; set; }

        public float Progress { get; set; }

        public TorrentPriority Priority { get; set; }

        public bool Seeding { get; set; }
    }
}
