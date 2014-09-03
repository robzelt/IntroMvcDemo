using System.Web.Mvc;
using System.Web.Routing;

namespace MvcDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Meeting-slash-id",
                url: "Meeting/{id}",
                defaults: new { controller = "Meetings", action = "Details", id = UrlParameter.Optional },
                constraints: new { id = @"\d+" }
                );

            routes.MapRoute(
                name: "Meeting",
                url: "Meeting{id}",
                defaults: new { controller = "Meetings", action = "Details", id = UrlParameter.Optional },
                constraints: new { id = @"\d+" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MvcDemo.Controllers" }
            );
        }
    }
}
