using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using System.Text;

namespace WebApi.DataService.Filters
{
    /// <summary>
    /// RequireHttpsAttribute give us the ability to decorate classes and methods with [RequireHttps].
    /// Security concepts and code came from the PluralSight - Implementing an API in ASP.NET Web API course.
    /// http://pluralsight.com/training/Courses/Description/implementing-restful-aspdotnet-web-api
    /// </summary>
    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var req = actionContext.Request;

            if (req.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                var html = "<p>Https is required</p>";
                if (req.Method.Method == "GET")
                {
                    actionContext.Response = req.CreateResponse(HttpStatusCode.Found);
                    actionContext.Response.Content = new StringContent(html, Encoding.UTF8, "text/html");

                    var uriBuilder = new UriBuilder(req.RequestUri);
                    uriBuilder.Scheme = Uri.UriSchemeHttps;
                    uriBuilder.Port = 443;

                    actionContext.Response.Headers.Location = uriBuilder.Uri;
                }
                else
                {
                    actionContext.Response = req.CreateResponse(HttpStatusCode.NotFound);
                    actionContext.Response.Content = new StringContent(html, Encoding.UTF8, "text/html");
                }
            }
        }
    }
}