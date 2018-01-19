using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing.Constraints;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace SomeWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //enable CORS
            config.EnableCors();

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ActionRoute",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Get" , id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
