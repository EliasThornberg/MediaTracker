using StructureMap;
using TorrentTrackerAPI.DependencyInject.Registers;

namespace TorrentTrackerAPI.DependencyInject
{
    public class StructureMapInitializer
    {
        public static IContainer Initialize()
        {
            return new Container(c =>
            {
                c.AddRegistry<ServiceRegistry>();
                c.AddRegistry<CommonRegistry>();
                c.AddRegistry<HandlerRegistry>();
            });
        }
    }
}