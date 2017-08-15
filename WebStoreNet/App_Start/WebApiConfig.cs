using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.Cors;

namespace WebStoreNet
{   

    //clase agregada segun
    //Part 6 ASP NET Web API MediaTypeFormatter
    //https://www.youtube.com/watch?v=tNzgXjqqIjI
    
    //public class CustomJsonFormater : JsonMediaTypeFormatter
    //{
    //    public CustomJsonFormater()
    //    {
    //        this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
    //    }

    //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
    //    {
    //        base.SetDefaultContentHeaders(type, headers, mediaType);
    //        headers.ContentType = new MediaTypeHeaderValue("application/json");
    //    }

    //}
    
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



            EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");
            config.EnableCors(cors);

            //config.Filters.Add(new RequireHttpAttribute());


            //---------------------
            //esto se hace para poder accesar desde distintos origenes con jsonp
            //Part 14 Calling ASP NET Web API service in a cross domain using jQuery ajax
            //var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0, jsonpFormatter);
            //---------------------

            // pruebas segun videos 
            //config.Formatters.Add(new CustomJsonFormater());
            //config.Formatters.Remove(config.Formatters.JsonFormatter);
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
