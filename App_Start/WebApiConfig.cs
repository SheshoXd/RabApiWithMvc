using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RabApiWithMvc
{

    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {


            //Enable Access-Control-Allow-Origin(CORS)
            var corc = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corc);

            // Web API configuration and services


            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            jsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;



            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
            Newtonsoft.Json.PreserveReferencesHandling.None;

            ((DefaultContractResolver)config.Formatters.JsonFormatter.SerializerSettings.ContractResolver).IgnoreSerializableAttribute = true;

            // Remove the xml frommater from web api 
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //Enable Query  Support  
            //config.EnableQuerySupport();

            // Web API routes
            config.MapHttpAttributeRoutes();


            //lookups 
            config.Routes.MapHttpRoute(
               name: "ActionApi",
               routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // config.Routes.MapHttpRoute(
            //    name: "ActionParameterApi",
            //    routeTemplate: "api/{controller}/{action}/{compCode}/{branchCode}"
            //);
            // config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);











            // Web API configuration and services

            //  Web API routes
            //config.MapHttpAttributeRoutes();



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
        //public static void Register(HttpConfiguration config)
        //{
        //    // Web API configuration and services

        //    // Web API routes
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );
        //}
    }
    //public static class WebApiConfig
    //{
    //    public static void Register(HttpConfiguration config)
    //    {
    //        // Web API configuration and services

    //        // Web API routes
    //        config.MapHttpAttributeRoutes();

    //        config.Routes.MapHttpRoute(
    //            name: "DefaultApi",
    //            routeTemplate: "api/{controller}/{id}",
    //            defaults: new { id = RouteParameter.Optional }
    //        );
    //    }
    //}
}
