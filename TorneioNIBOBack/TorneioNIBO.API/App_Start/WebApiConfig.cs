
using System.Web.Http;
using System.Web.Http.Cors;

namespace TorneioNIBO.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();
            UnityConfig.RegisterComponents();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add
                (new Newtonsoft.Json.Converters.StringEnumConverter());
            /*
            GlobalConfiguration.Configuration.Formatters
                   .JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling
                   = ReferenceLoopHandling.Ignore;
                */
        }
    }
}
