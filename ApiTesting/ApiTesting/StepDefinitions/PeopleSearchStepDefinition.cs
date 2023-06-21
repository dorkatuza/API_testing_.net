using ApiTesting.Support;
using ApiTesting.Support.JsonObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class PeopleSearchStepDefinitions: ResponseHandler
    {

        [Given(@"the people ID is: (.*)")]
        public async Task GivenThePeopleIDIsAsync(int peopleId)
        {
            string endpointPath = "people/";
            await APICallHandler.GetResponse(endpointPath, peopleId);
        }

        [Then(@"the people name is: ([^']*)")]
        public void ThenThePeopleNameIs(string peopleName)
        {
            string ResponseContent = Response.Content;
            People PeopleData = JsonConvert.DeserializeObject<People>(ResponseContent);

            string PeopleName = PeopleData.name;
            peopleName.Should().Be(PeopleName);
        }
    }
}
