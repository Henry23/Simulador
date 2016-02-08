using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Simulador
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{resource}.config");

            routes.MapRoute(
                name: "Datos",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Datos", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Datos1",
               url: "",
               defaults: new { controller = "Datos", action = "Create", id = UrlParameter.Optional }
           );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
