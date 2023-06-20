using ApiTesting.Support;
using ApiTesting.Support.JsonObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class ResidenceStepDefinitions : ResponseHandler
    {
        [Then(@"the planet is the residence for people like:")]
        public void ThenTheResidenceListAre(Table residentsTable)
        {
            string responseContent = Response.Content;
            Planet planetData = JsonConvert.DeserializeObject<Planet>(responseContent);

            List<string> residentsURLList = planetData.residents.Select(r => r.ToString()).ToList();
            //Console.WriteLine("Residents list: " + string.Join(", ", residents));

            List<string> expectedResidents = residentsTable.Rows.Select(row => row["CharacterName"]).ToList();
            List<string> residentsFromResponse = new List<string>();

            foreach (string ResidentURL in residentsURLList)
            {
                string[] peopleUrl = ResidentURL.Split('/');
                string endpointPath = peopleUrl[4] + "/";
                int peopleId = int.Parse(peopleUrl[5]);
                APICallHandler.GetResponse(endpointPath, peopleId);
                string responsePeople = Response.Content;
                People people = JsonConvert.DeserializeObject<People>(responsePeople);
                residentsFromResponse.Add(people.name);
            }
            residentsFromResponse.Should().BeEquivalentTo(expectedResidents);
        }
    }
}
