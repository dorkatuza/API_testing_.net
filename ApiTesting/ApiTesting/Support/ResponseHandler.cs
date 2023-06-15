using RestSharp;

namespace ApiTesting.Support
{
    public class ResponseHandler
    {
        private static RestResponse response;
        public static RestResponse Response { get => response; set => response = value; }
    }
}
