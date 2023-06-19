using ApiTesting.Support;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTesting.StepDefinitions
{
    [Binding]
    public class CommonStepDefinition: ResponseHandler
    {

        [When(@"response status is: (.*)")]
        public void WhenResponseStatusIs(string responseStatus)
        {
            Assert.Equal(responseStatus, Response.StatusCode.ToString());
        }
 
    }
}
