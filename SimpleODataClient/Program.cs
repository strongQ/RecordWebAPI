using EF.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleODataClient
{
    class Program
    {
        static  void Main(string[] args)
        {

            HttpClient client = new HttpClient();
            
            GetDatas(client);

            JObject postContent = JObject.Parse(@"{
    'ID':1,
    'UserName':'lihui',
    'IP':'23',
    'Email':'xdfsd',
    'Password':'xcvc',






}");
            HttpResponseMessage response = client.PostAsJsonAsync("Http://localhost:55509/Odata/Users", postContent).Result;

           
            //Task.Run(async () =>
            //{
            //    var response = await client.PostAsync("http://localhost:55509/OData", content);
            //    //确保HTTP成功状态值
            //    response.EnsureSuccessStatusCode();
            //    //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
            //    Console.WriteLine(await response.Content.ReadAsStringAsync());
            //}).Wait();
            GetDatas(client);

            Console.ReadKey();
        }

        private static async void GetDatas(HttpClient client)
        {
          var result=await  client.GetAsync("http://localhost:55509/OData/Users");
           string data=await result.Content.ReadAsStringAsync();
            JObject a = JObject.Parse(data);

            IEnumerable<MyUser> b =JsonConvert.DeserializeObject<List<MyUser>>( a["value"].ToString());


        }
      
}
    }

