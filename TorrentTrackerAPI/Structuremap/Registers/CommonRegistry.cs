using StructureMap;
using System.Configuration;
using TorrentTracker.Core.Interface.Cache;
using TorrentTracker.Data;
using TorrentTracker.Data.OMDbApi.Client;
using TorrentTracker.Data.qBittorrentAPI.Client;
using TorrentTracker.Data.StringApproximation;

namespace TorrentTrackerAPI.DependencyInject.Registers
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            For<IqBittorrentClient>().Use<qBittorrentClient>();
            var tmdbKey = ConfigurationManager.AppSettings["TMDBKey"];
            For<ITMDBClient>().Use(() => new TMDBClient(tmdbKey));
            For<ICache>().Use<Cache>();
            For<IStringApproximationFactory>().Use<StringApproximationFactory>();
        }
    }
}