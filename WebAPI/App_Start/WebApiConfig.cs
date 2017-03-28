using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Newtonsoft.Json.Serialization;
using Samples.WebAPI.Helpers;
using Samples.WebAPI.Providers;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.MessageHandlers.Add(new MyMessageHandler());

            config.SetCorsPolicyProviderFactory(new MyCorsPolicyFactory());
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Services.Add(typeof(IExceptionLogger), new TraceExceptionLogger(new TraceSource("MyTraceSource", SourceLevels.Error)));
        }
    }
}
