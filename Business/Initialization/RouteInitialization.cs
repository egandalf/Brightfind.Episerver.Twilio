using System.Web.Mvc;
using System.Web.Routing;
using Brightfind.Episerver.Twilio.App_Start;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace Brightfind.Episerver.Twilio.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    internal class RouteInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}
