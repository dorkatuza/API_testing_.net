using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class CommonStepDefinition
    {
        private static RestResponse response;

        public static RestResponse Response { get => response; set => response = value; }

        [When(@"response status is: (.*)")]
        public void WhenResponseStatusIs(string responseStatus)
        {
            Assert.Equal(responseStatus, Response.StatusCode.ToString());
        }
 
    }
}
