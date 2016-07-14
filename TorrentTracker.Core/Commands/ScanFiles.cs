using System.Collections.Generic;
using TorrentTracker.Core.Entities.Media;
using TorrentTracker.Core.Interface.CQRS;

namespace TorrentTracker.Core.Commands
{
    public class ScanMovies : ICommand<IEnumerable<Movie>>
    {
        public List<string> FoldersToScan { get; set; }

        public List<string> ExcludeFiletypes { get; set; }
    }
}
