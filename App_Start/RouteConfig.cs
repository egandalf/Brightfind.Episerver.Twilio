using System.Web.Routing;
using System.Web.Mvc;

namespace Brightfind.Episerver.Twilio.App_Start
{
    internal class RouteConfig
    {
        internal static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "TwilioAdmin",
                url: "modules/Brightfind.Episerver.Twilio/{controller}/{action}",
                defaults: new { controller = "TwilioAdmin", action = "Index" }
                );
        }
    }
}
