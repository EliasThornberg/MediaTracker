using TorrentTracker.Core.Entities.Common;

namespace TorrentTracker.Core.Entities.Media
{
    public class Episode : Entity
    {
        public Episode(string title, int episodeNumber)
        {
            Title = title;
            EpisodeNumber = episodeNumber;
        }

        public string Title { get; set; }

        public int EpisodeNumber { get; set; }
    }
}
