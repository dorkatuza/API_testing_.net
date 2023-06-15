using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTesting.Support
{
    public class ResponseHandler
    {
        private static RestResponse response;
        public static RestResponse Response { get => response; set => response = value; }
    }
}
