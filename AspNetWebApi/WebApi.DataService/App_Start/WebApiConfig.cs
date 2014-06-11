using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebApi.DataService.Filters;
using Newtonsoft.Json.Serialization;
//using WebApiContrib.Formatting.Jsonp;


namespace WebApi.DataService.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            //var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //// Add support JSONP
            //var formatter = new JsonpMediaTypeFormatter(jsonFormatter, "cb");
            //config.Formatters.Insert(0, formatter);

            //#if !DEBUG
            //      // Force HTTPS on entire API
            //      config.Filters.Add(new RequireHttpsAttribute());
            //#endif

        }


        /// <summary>
        /// CreateMediaTypes is used if you want to use MediaType for versioning of WebApi service.
        /// Versioning concepts and code came from the PluralSight - Implementing an API in ASP.NET Web API course.
        /// http://pluralsight.com/training/Courses/Description/implementing-restful-aspdotnet-web-api
        /// See the BaseControllerSelector class for versioning methods.
        /// The JsonMediaTypeFormatter is in the WebApiContrib.Formatting.Jsonp namespace.
        /// </summary>
        /// <param name="jsonFormatter"></param>
        //static void CreateMediaTypes(JsonMediaTypeFormatter jsonFormatter)
        //{
        //    var mediaTypes = new string[] 
        //{ 
        //  "application/vnd.servicename.entity.v1+json",
        //  "application/vnd.servicename.entity.v2+json",
        //};

        //    foreach (var mediaType in mediaTypes)
        //    {
        //        jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue(mediaType));
        //    }

        //}    

    }
}