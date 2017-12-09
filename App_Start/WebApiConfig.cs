using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAppMaze
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "NameApi",
                routeTemplate: "api/{controller}/{name}",
                defaults: new { name = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "RegisterApi",
               routeTemplate: "api/{controller}/{Name}/{Pass}",
               defaults: new {Name = RouteParameter.Optional , Pass = RouteParameter.Optional
               }
           );
        }
    }
}
