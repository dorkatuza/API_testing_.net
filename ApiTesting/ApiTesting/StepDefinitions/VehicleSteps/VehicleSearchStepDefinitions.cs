using ApiTesting.Support;
using ApiTesting.Support.JsonObjects;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class VehicleSearchStepDefinitions : ResponseHandler
    {

        [Given(@"the vehicle ID is: (.*)")]
        public async Task GivenTheVehicleIDIsAsync(int vehicleId)
        {
            string endpointPath = "vehicles/";
            await APICallHandler.GetResponse(endpointPath, vehicleId);
        }

        [Then(@"the vehicle name is: ([^']*)")]
        public void ThenTheVehicleNameIs(string vehicleName)
        {
            string ResponseContent = Response.Content;
            Vehicle VehicleData = JsonConvert.DeserializeObject<Vehicle>(ResponseContent);

            string VehicleName = VehicleData.name;
            vehicleName.Should().Be(VehicleName);
        }
    }
}
