using ApiTesting.Support;
using ApiTesting.Support.JsonObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class PlanetSearchStepDefinitions : RequestHandler
    {

        [Given(@"the planet ID is: (.*)")]
        public async Task GivenThePlanetIDIsAsync(int planetId)
        {
            string BaseURL = "https://swapi.dev/api/";
            string endpoint = BaseURL + "planets/" + planetId;
            var Client = new RestClient(endpoint, configureSerialization: s => s.UseNewtonsoftJson());
            RestRequest Request = new RestRequest(endpoint) { Method = Method.Get };
            Request.AddHeader("Content-Type", "application/json");
            Request.AddHeader("Accept", "application/json");
            Response = await Client.GetAsync(Request);
        }

        [Then(@"the planet name is: ([^']*)")]
        public void ThenThePlanetNameIs(string planetName)
        {
            string ResponseContent = Response.Content;
            Planet PlanetData = JsonConvert.DeserializeObject<Planet>(ResponseContent);

            string PlanetName = PlanetData.name;
            Assert.True(PlanetName.Equals(planetName));
        }
    }
}
