using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace AngularJS_WebApi_EF
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "api-people",
                routeTemplate: "api/people",
                defaults: new { controller = "Person", action = "GetPeople" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
                );

            config.Routes.MapHttpRoute(
                name: "api-person",
                routeTemplate: "api/people/person",
                defaults: new { controller = "Person", action = "GetUser" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
                );

            config.Routes.MapHttpRoute(
                name: "api-search",
                routeTemplate: "api/people/search",
                defaults: new { controller = "Person", action = "Search" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
                );

            config.Routes.MapHttpRoute(
                name: "api-comment",
                routeTemplate: "api/people/comment",
                defaults: new { controller = "Person", action = "PostComment" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
                );

        }
    }
}
