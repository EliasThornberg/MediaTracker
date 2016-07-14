using StructureMap;
using System.Collections.Generic;
using TorrentTracker.Core.Commands;
using TorrentTracker.Core.Entities.Media;
using TorrentTracker.Core.Interface.CQRS;
using TorrentTracker.Data.FileService;

namespace TorrentTrackerAPI.DependencyInject.Registers
{
    public class HandlerRegistry : Registry
    {
        public HandlerRegistry()
        {
            For<IAsyncCommandHandler<ScanMovies, IEnumerable<Movie>>>().Use<ScanMoviesHandler>();
            For<IAsyncCommandHandler<ScanShows, IEnumerable<Show>>>().Use<ScanShowsHandler>();      
        }
    }
}