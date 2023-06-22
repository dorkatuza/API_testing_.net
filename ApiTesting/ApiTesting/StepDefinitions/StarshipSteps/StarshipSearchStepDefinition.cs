using ApiTesting.Support;
using ApiTesting.Support.JsonObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace ApiTesting.StepDefinitions.StarshipTests
{
    [Binding]
    public class StarshipSearchStepDefinitions : ResponseHandler
    {

        [Given(@"the starship ID is: (.*)")]
        public async Task GivenTheStarshipIDIsAsync(int starshipId)
        {
            string endpointPath = "starships/";
            await APICallHandler.GetResponse(endpointPath, starshipId);
        }

        [Then(@"the starship name is: ([^']*)")]
        public void ThenTheStarshipNameIs(string starshipName)
        {
            string ResponseContent = Response.Content;
            Starship StarshipData = JsonConvert.DeserializeObject<Starship>(ResponseContent);

            string StarshipName = StarshipData.name;
            starshipName.Should().Be(StarshipName);
        }
    }
}
