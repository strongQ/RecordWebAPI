using EF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdataClient
{
    public class ODataContainer : ODataV4ContextBase
    {
        public ODataContainer(string serviceRoot) : base(serviceRoot)
        {
        }
        public IQueryable<MyUser> Users
        {
            get
            {
                return base.CreateNewQuery<MyUser>("Users");
            }
        }
    }
}
