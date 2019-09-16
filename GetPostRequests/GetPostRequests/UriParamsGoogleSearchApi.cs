using System;
namespace GetPostRequests
{
    public class UriParamsGoogleSearchApi : IUriParams
    {
        public UriParamsGoogleSearchApi(UriGoogleSearchParams uriParams)
        {
            Uri = uriParams.Uri;
            UriParameters = $"?key={uriParams.Key}&cx={uriParams.SearchEngine}&q={uriParams.Query}";
        }

        public string Uri { get; set; }
        public string UriParameters { get; set; }
        
    }
}
