using StructureMap;
using TorrentTracker.Core.Interface.ApplicationService;
using TorrentTracker.Core.Interface.ExternalServices;
using TorrentTracker.Data.FileService;
using TorrentTracker.Data.qBittorrentAPI;
using TorrentTracker.Data.Service.OMDbApi;

namespace TorrentTrackerAPI.DependencyInject.Registers
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<ITorrentService>().Use<TorrentService>();
            For<IMovieService>().Use<OMDbMovieService>();
            For<IMediaFileService<MediaInfo>>().Use<MediaFileService>();
        }
    }
}