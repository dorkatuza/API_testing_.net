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
    public class FilmSearchStepDefinitions : ResponseHandler
    {

        [Given(@"the film ID is: (.*)")]
        public async Task GivenTheFilmIDIsAsync(int filmId)
        {
            string endpointPath = "films/";
            await APICallHandler.GetResponse(endpointPath, filmId);
        }

        [Then(@"the film title is: ([^']*)")]
        public void ThenTheFilmTitleIs(string filmTitle)
        {
            string ResponseContent = Response.Content;
            Film FilmData = JsonConvert.DeserializeObject<Film>(ResponseContent);

            string FilmTitle = FilmData.title;
            filmTitle.Should().Be(FilmTitle);
        }
    }
}