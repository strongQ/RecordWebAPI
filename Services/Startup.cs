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
            builder.EntitySet<MyUser>("User");
            return builder.GetEdmModel();
        }
    }
}
