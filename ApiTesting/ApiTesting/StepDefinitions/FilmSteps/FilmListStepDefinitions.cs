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
    public class FilmListStepDefinitions : ResponseHandler
    {

        [Given(@"the film endpoint: (.*)")]
        public async Task GivenTheFilmEndpointIsAsync(string endpointPath)
        {
            await APICallHandler.GetResponse(endpointPath);
        }

        [Then(@"the film titles are:")]
        public void ThenTheFilmListTitlesAre(Table filmTitles)
        {
            List<string> expectedFilms = filmTitles.Rows.Select(row => row["FilmTitles"]).ToList();

            string ResponseContent = Response.Content;
            FilmList filmList = JsonConvert.DeserializeObject<FilmList>(ResponseContent);

            List<string> filmTitlesFromResponse = filmList.results.Select(film => film.title).ToList();

            expectedFilms.Should().BeEquivalentTo(filmTitlesFromResponse);
        }
    }
}