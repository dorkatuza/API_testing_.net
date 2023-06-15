using ApiTesting.Support;
using ApiTesting.Support.JsonObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class StarshipSearchStepDefinitions: RequestHandler
    {

        [Given(@"the starship ID is: (.*)")]
        public async Task GivenTheStarshipIDIsAsync(int starshipId)
        {
            string BaseURL = "https://swapi.dev/api/";
            string endpoint = BaseURL + "starships/" + starshipId;
            var Client = new RestClient(endpoint, configureSerialization: s => s.UseNewtonsoftJson());
            RestRequest Request = new RestRequest(endpoint) { Method = Method.Get };
            Request.AddHeader("Content-Type", "application/json");
            Request.AddHeader("Accept", "application/json");
            Response = await Client.GetAsync(Request);
        }

        [Then(@"the starship name is: ([^']*)")]
        public void ThenTheStarshipNameIs(string starshipName)
        {
            string ResponseContent = Response.Content;
            Starship StarshipData = JsonConvert.DeserializeObject<Starship>(ResponseContent);

            string StarshipName = StarshipData.name;
            Assert.True(StarshipName.Equals(starshipName));
        }
    }
}
