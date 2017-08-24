using EF.Core;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.OData.Builder;

namespace Services
{
    public class Startup
    {
        public static IEdmModel GenerateEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
           
              builder.EntitySet<MyUser>("Users");
            //FunctionConfiguration getUser = builder.Function("GetUser");
            //getUser.Parameter<string>("UserName");
            //getUser.ReturnsCollectionFromEntitySet<MyUser>("User");
            builder.Namespace = "UserService";
            builder.EntityType<MyUser>().Collection.Function("GetMaxID").Returns<int>();
            builder.EntityType<MyUser>().Collection.Function("GetMaxName").Returns<Module>();

            builder.Function("GetSome").Returns<double>().Parameter<int>("ID");
            return builder.GetEdmModel();
        }
    }
}
