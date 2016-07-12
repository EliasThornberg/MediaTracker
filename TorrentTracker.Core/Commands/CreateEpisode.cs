using TorrentTracker.Core.Entities.Media;
using TorrentTracker.Core.Interface.CQRS;

namespace TorrentTracker.Core.Commands
{
    public class CreateEpisode : ICommand<Episode>
    {
        public int SeasonId { get; set; }

        public string Title { get; set; }

        public int EpisodeNumber { get; set; }
    }
}
