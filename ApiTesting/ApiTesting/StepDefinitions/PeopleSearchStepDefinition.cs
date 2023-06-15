using ApiTesting.Support;
using ApiTesting.Support.JsonObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class PeopleSearchStepDefinitions: ResponseHandler
    {

        [Given(@"the people ID is: (.*)")]
        public async Task GivenThePeopleIDIsAsync(int peopleId)
        {
            string BaseURL = "https://swapi.dev/api/";
            string endpoint = BaseURL + "people/" + peopleId;
            var Client = new RestClient(endpoint, configureSerialization: s => s.UseNewtonsoftJson());
            RestRequest Request = new RestRequest(endpoint) { Method = Method.Get };
            Request.AddHeader("Content-Type", "application/json");
            Request.AddHeader("Accept", "application/json");
            Response = await Client.GetAsync(Request);
        }

        [Then(@"the people name is: ([^']*)")]
        public void ThenThePeopleNameIs(string peopleName)
        {
            string ResponseContent = Response.Content;
            People PeopleData = JsonConvert.DeserializeObject<People>(ResponseContent);

            string PeopleName = PeopleData.name;
            Assert.True(PeopleName.Equals(peopleName));
        }
    }
}
