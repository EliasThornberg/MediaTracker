using System.Collections.Generic;
using TorrentTracker.Core.Entities.Media;
using TorrentTracker.Core.Interface.CQRS;
using TorrentTracker.Core.Sharedkernel;

namespace TorrentTracker.Core.Commands
{
    public class CreateMovie : ICommand<Movie>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<Genre> Genres { get; set; }
    }
}
