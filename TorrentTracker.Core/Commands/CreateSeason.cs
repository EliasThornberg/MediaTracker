using System;
using TorrentTracker.Core.Entities.Media;
using TorrentTracker.Core.Interface.CQRS;

namespace TorrentTracker.Core.Commands
{
    public class CreateSeason : ICommand<Season>
    {
        public int ShowId { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
