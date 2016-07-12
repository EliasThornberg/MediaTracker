using TorrentTracker.Core.Entities.Media;
using TorrentTracker.Core.Interface.CQRS;

namespace TorrentTracker.Core.Commands
{
    public class CreateShow : ICommand<Show>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
