using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "LotsByCategory",
                url: "Home/Index/{categoryId}/{page}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    categoryId = UrlParameter.Optional,
                    page = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "404-catch-all",
                "{*catchall}",
                new
                {
                    Controller = "Error",
                    Action = "NotFound"
                });


        }
    }
}
