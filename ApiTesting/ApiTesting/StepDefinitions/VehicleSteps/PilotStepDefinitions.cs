using ApiTesting.Support;
using ApiTesting.Support.JsonObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class PilotStepDefinitions : ResponseHandler
    {
        [Then(@"the pilots are of the given vehicle:")]
        public async Task ThenThePilotListAreAsync(Table pilotsTable)
        {
            string responseContent = Response.Content;
            Vehicle vehicleData = JsonConvert.DeserializeObject<Vehicle>(responseContent);

            List<string> pilotsURLList = vehicleData.pilots.Select(r => r.ToString()).ToList();

            List<string> expectedPilots = pilotsTable.Rows.Select(row => row["CharacterName"]).ToList();
            List<string> pilotsFromResponse = new List<string>();

            foreach (string PilotURL in pilotsURLList)
            {
                string[] peopleUrl = PilotURL.Split('/');
                string endpointPath = peopleUrl[4] + "/";
                int peopleId = int.Parse(peopleUrl[5]);
                await APICallHandler.GetResponse(endpointPath, peopleId);
                string responsePeople = Response.Content;
                People people = JsonConvert.DeserializeObject<People>(responsePeople);
                pilotsFromResponse.Add(people.name);
            }
            pilotsFromResponse.Should().BeEquivalentTo(expectedPilots);
        }
    }
}

