using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverUri = "http://localhost:55509/OData";
            var container = new ODataContainer(serverUri);
            var datas = container.Users.ToList();
            
            Console.ReadKey();
        }
    }
}
