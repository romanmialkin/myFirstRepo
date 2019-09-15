using System;

namespace GetPostRequests
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var getRequest = new GetRequest();

            getRequest.GetReq(new UriParamsGoogleSearchApi(
                UriParams.uri, UriParams.key, UriParams.searchEngine, UriParams.query));*/

            var postRequest = new PostRequest();

            postRequest.PostReq(new UriParamsGoogleSearchApi(
                UriParams.uri, UriParams.key, UriParams.searchEngine, UriParams.query));



            Console.ReadLine();
        }
    }
}
