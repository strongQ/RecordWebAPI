using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData.Extensions;

namespace OwinService
{
    class Program
    {
        static readonly Uri _baseAddress = new Uri("http://localhost:55509");
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url: _baseAddress.OriginalString))
            {
                Console.WriteLine("listening");
                Console.ReadLine();
            }
        }
    }
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Set up server configuration
            var config = new HttpConfiguration() { IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always };

            // Enables OData support by adding an OData route and enabling querying support for OData.
            // Action selector and odata media type formatters will be registered in per-controller configuration only
            config.MapODataServiceRoute(
                routeName: "OData",
                routePrefix: null,
                model:  Services.Startup.GenerateEdmModel());

            appBuilder.UseWebApi(config);

            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        }

    }
}
