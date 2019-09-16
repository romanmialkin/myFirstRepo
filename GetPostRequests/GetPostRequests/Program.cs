using System;

namespace GetPostRequests
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchParams = new UriGoogleSearchParams();
            var getRequest = new GetRequest();

            getRequest.GetReq(new UriParamsGoogleSearchApi(searchParams));

            var postRequest = new PostRequest();

            //postRequest.PostReq(new UriParamsGoogleSearchApi(searchParams));



            Console.ReadLine();
        }
    }
}
