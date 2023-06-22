using ApiTesting.Support;
using ApiTesting.Support.JsonObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class FilmStepDefinitions : ResponseHandler
    {
        [Then(@"the planet is the place for films like:")]
        public async Task ThenTheFilmListAreAsync(Table filmsTable)
        {
            string responseContent = Response.Content;
            Planet planetData = JsonConvert.DeserializeObject<Planet>(responseContent);

            List<string> filmURLList = planetData.films.Select(r => r.ToString()).ToList();

            List<string> expectedFilms = filmsTable.Rows.Select(row => row["FilmTitle"]).ToList();
            List<string> filmsFromResponse = new List<string>();

            foreach (string FilmURL in filmURLList)
            {
                string[] filmUrl = FilmURL.Split('/');
                string endpointPath = filmUrl[4] + "/";
                int filmId = int.Parse(filmUrl[5]);
                await APICallHandler.GetResponse(endpointPath, filmId);
                string responseFilm = Response.Content;
                Film film = JsonConvert.DeserializeObject<Film>(responseFilm);
                filmsFromResponse.Add(film.title);
            }
            filmsFromResponse.Should().BeEquivalentTo(expectedFilms);
        }
    }
}
