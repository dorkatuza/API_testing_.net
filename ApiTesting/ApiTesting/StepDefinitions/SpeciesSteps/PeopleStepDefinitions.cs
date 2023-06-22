using ApiTesting.Support;
using ApiTesting.Support.JsonObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class PeopleStepDefinitions : ResponseHandler
    {
        [Then(@"the people are for the given species:")]
        public async Task ThenThePeopleListAreAsync(Table peopleTable)
        {
            string responseContent = Response.Content;
            Species speciesData = JsonConvert.DeserializeObject<Species>(responseContent);

            List<string> peopleURLList = speciesData.people.Select(r => r.ToString()).ToList();

            List<string> expectedPeople = peopleTable.Rows.Select(row => row["CharacterName"]).ToList();
            List<string> peopleFromResponse = new List<string>();

            foreach (string PeopleURL in peopleURLList)
            {
                string[] peopleUrl = PeopleURL.Split('/');
                string endpointPath = peopleUrl[4] + "/";
                int peopleId = int.Parse(peopleUrl[5]);
                await APICallHandler.GetResponse(endpointPath, peopleId);
                string responsePeople = Response.Content;
                People people = JsonConvert.DeserializeObject<People>(responsePeople);
                peopleFromResponse.Add(people.name);
            }
            peopleFromResponse.Should().BeEquivalentTo(expectedPeople);
        }
    }
}

