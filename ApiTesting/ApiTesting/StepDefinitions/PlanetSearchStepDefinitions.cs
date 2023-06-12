using RestSharp;
using System;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using RestSharp.Serializers.NewtonsoftJson;
using ApiTesting.Support.JsonObjects;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class PlanetSearchStepDefinitions
    {
        RestResponse PlanetResponse;

        [Given(@"the planet ID is: (.*)")]
        public async Task GivenThePlanetIDIsAsync(int planetId)
        {
            string BaseURL = "https://swapi.dev/api/";
            string endpoint = BaseURL + "planets/" + planetId;
            var Client = new RestClient(endpoint, configureSerialization: s => s.UseNewtonsoftJson());
            RestRequest Request = new RestRequest(endpoint) { Method = Method.Get };
            Request.AddHeader("Content-Type", "application/json");
            Request.AddHeader("Accept", "application/json");
            PlanetResponse = await Client.GetAsync(Request);
        }

        [When(@"response status is: (.*)")]
        public void WhenResponseStatusIs(string responseStatus)
        {
            Assert.Equal(responseStatus, PlanetResponse.StatusCode.ToString());
        }

        [Then(@"the planet name is: ([^']*)")]
        public void ThenThePlanetNameIs(string planetName)
        {
            string ResponseContent = PlanetResponse.Content;
            Planet PlanetData = JsonConvert.DeserializeObject<Planet>(ResponseContent);

            string PlanetName = PlanetData.name;
            Assert.True(PlanetName.Equals(planetName));
        }
    }
}
