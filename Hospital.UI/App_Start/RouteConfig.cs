﻿using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.XPath;

namespace Hospital.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authentication", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Hospital.UI.Controllers" }
            );
        }
    }
}   
