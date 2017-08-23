using EF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;

using Microsoft.OData.Edm;
using System.Web.OData.Builder;

namespace RecordWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // Web API configuration and services
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            // Enables OData support by adding an OData route and enabling querying support for OData.
            // Action selector and odata media type formatters will be registered in per-controller configuration only
            config.MapODataServiceRoute(
              routeName: "OData",
              routePrefix: "OData",
              model: GenerateEdmModel());

            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional });
           
 
          

            //启用Odata查询
            //config.Formatters.JsonFormatter.AddQueryStringMapping("$format", "json", "application/json");
            //config.Formatters.XmlFormatter.AddQueryStringMapping("$format", "xml", "application/xml");

            
        }

        private static IEdmModel GenerateEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<MyUser>("User");
            return builder.GetEdmModel();
        }
    }
}
