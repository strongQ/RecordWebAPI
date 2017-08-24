using Microsoft.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdataClient
{
    public class ODataV4ContextBase : DataServiceContext
    {
        /// <summary>
        /// V4 OData Init
        /// </summary>
        /// <param name="serviceRoot">V4 OData ASP.NET WebAPI url base</param>
        public ODataV4ContextBase(string serviceRoot)
            : base(new System.Uri(serviceRoot), ODataProtocolVersion.V4)
        {
            if (!serviceRoot.EndsWith("/"))
                serviceRoot = serviceRoot + "/";
            GeneratedEdmModel gem = new GeneratedEdmModel(serviceRoot);
            this.Format.LoadServiceModel = gem.GetEdmModel;
            this.Format.UseJson();
        }

        public IQueryable<T> CreateNewQuery<T>(string name) where T : class
        {
            return base.CreateQuery<T>(name);
        }

       public class GeneratedEdmModel
        {
            private string ServiceRootUrl;
            public GeneratedEdmModel(string serviceRootUrl)
            {
                this.ServiceRootUrl = serviceRootUrl;
            }

            public Microsoft.OData.Edm.IEdmModel GetEdmModel()
            {
                string metadataUrl = ServiceRootUrl + "$metadata";
                return LoadModelFromUrl(metadataUrl);
            }

            private Microsoft.OData.Edm.IEdmModel LoadModelFromUrl(string metadataUrl)
            {
                System.Xml.XmlReader reader = CreateXmlReaderFromUrl(metadataUrl);
                try
                {
                    return Microsoft.OData.Edm.Csdl.EdmxReader.Parse(reader);
                }
                finally
                {
                    ((System.IDisposable)(reader)).Dispose();
                }
            }

            private static System.Xml.XmlReader CreateXmlReaderFromUrl(string inputUri)
            {
                return System.Xml.XmlReader.Create(inputUri);
            }
        }
    }
}
