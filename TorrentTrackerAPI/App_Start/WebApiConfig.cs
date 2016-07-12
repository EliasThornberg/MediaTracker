using StructureMap;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using TorrentTrackerAPI.DependencyInject;

namespace TorrentTrackerAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //DI stuff
            IContainer container = StructureMapInitializer.Initialize();
            config.Services.Replace(typeof(IHttpControllerActivator), new StructureMapControllerActivator(container));

            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
