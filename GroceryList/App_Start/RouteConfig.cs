﻿using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace GroceryList
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
        name: "swagger_root",
        routeTemplate: "",
        defaults: null,
        constraints: null,
        handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));
        }
    }
}
