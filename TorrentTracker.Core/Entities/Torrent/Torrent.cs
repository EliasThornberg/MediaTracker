using TorrentTracker.Core.Entities.Common;

namespace TorrentTracker.Core.Entities.Torrent
{
    public class Torrent : AggregateRoot
    {
        public string TorrentHash { get; set; }

        public string Title { get; set; }

        public string Label { get; set; }

        public float Progress { get; set; }

        public long Size { get; set; }

        public int Downloadspeed { get; set; }

        public int Uploadspeed { get; set; }

        public int ETAInSeconds { get; set; }

        public TorrentState State { get; set; }
    }
}
