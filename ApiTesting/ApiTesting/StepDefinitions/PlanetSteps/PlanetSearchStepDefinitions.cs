using ApiTesting.Support;
using ApiTesting.Support.JsonObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class PlanetSearchStepDefinitions : ResponseHandler
    {

        [Given(@"the planet ID is: (.*)")]
        public async Task GivenThePlanetIDIsAsync(int planetId)
        {
            string endpointPath = "planets/";
            await APICallHandler.GetResponse(endpointPath, planetId);
        }

        [Then(@"the planet name is: ([^']*)")]
        public void ThenThePlanetNameIs(string planetName)
        {
            string ResponseContent = Response.Content;
            Planet PlanetData = JsonConvert.DeserializeObject<Planet>(ResponseContent);

            string PlanetName = PlanetData.name;
            planetName.Should().Be(PlanetName);
        }
    }
}
