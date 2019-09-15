using System;
namespace GetPostRequests
{
    public class UriParamsGoogleSearchApi : IUriParams
    {
        public UriParamsGoogleSearchApi(string uri, string key, string searchEngine, string query)
        {
            Uri = uri;
            UriParameters = $"?key={key}&cx={searchEngine}&q={query}";
        }

        public string Uri { get; set; }
        public string UriParameters { get; set; }
        
    }
}
