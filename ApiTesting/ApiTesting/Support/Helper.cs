using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Serializers.NewtonsoftJson;

namespace ApiTesting.Support
{
    [Binding]
    public class Helper: ResponseHandler
    {
        public async static void GetResponse(string contentType, int givenId)
        {
            string BaseURL = "https://swapi.dev/api/";
            string endpoint = BaseURL + contentType + givenId;
            var Client = new RestClient(endpoint, configureSerialization: s => s.UseNewtonsoftJson());
            RestRequest Request = new RestRequest(endpoint) { Method = Method.Get };
            Request.AddHeader("Content-Type", "application/json");
            Request.AddHeader("Accept", "application/json");
            RestResponse restResponse = await Client.GetAsync(Request);
            Response = restResponse;


        }
    }
}
