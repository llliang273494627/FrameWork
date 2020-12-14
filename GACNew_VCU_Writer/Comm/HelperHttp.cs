using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GACNew_VCU_Writer.Comm
{
    public class HelperHttp
    {
        public async static Task<T> ApiPost<T>(string url,object body)
        {
            var client = new RestClient($"{url}");
            IRestRequest queest = new RestRequest
            {
                Method = Method.POST,
            };
            queest.AddHeader("Accept", "application/json");
            queest.AddJsonBody(body);
            var result =await client.ExecuteAsync(queest);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                return (T)Convert.ChangeType(result.ErrorMessage, typeof(T));
            }
            var temp = Newtonsoft.Json.JsonConvert.DeserializeObject(result.Content, typeof(T));
            return (T)temp;
        }

    }
}
