using ApiTesting.Support.JsonObjects;
using ApiTesting.Support;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTesting.StepDefinitions.FilmSteps
{
    [Binding]
    public class SpeciesSearchStepDefinitions : ResponseHandler
    {

        [Given(@"the species ID is: (.*)")]
        public async Task GivenTheSpeciesIDIsAsync(int speciesId)
        {
            string endpointPath = "species/";
            await APICallHandler.GetResponse(endpointPath, speciesId);
        }

        [Then(@"the species name is: ([^']*)")]
        public void ThenTheSpeciesNameIs(string speciesName)
        {
            string ResponseContent = Response.Content;
            Species SpeciesData = JsonConvert.DeserializeObject<Species>(ResponseContent);

            string SpeciesName = SpeciesData.name;
            speciesName.Should().Be(SpeciesName);
        }
    }
}


