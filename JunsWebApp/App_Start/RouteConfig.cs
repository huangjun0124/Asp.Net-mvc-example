using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JunsWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ipaddr/Score/jun ok with name = "" or name= UrlParameter.Optional
            // http://localhost:1588/Score?name=jun ok with name= UrlParameter.Optional 
            // if delete name = ..., url must input with /Score/name, /Score is not ok
            routes.MapRoute(
                name:"Score",
                url:"Score/{name}",
                defaults: new {controller = "Score", action = "Search", name= UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
