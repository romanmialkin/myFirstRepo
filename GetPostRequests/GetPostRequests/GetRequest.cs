using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GetPostRequests
{
    public class GetRequest
    {            

        public async void GetReq(IUriParams uri)
        {
            

            var client = new HttpClient() { BaseAddress = new Uri(uri.Uri) };

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(uri.UriParameters);
            response.EnsureSuccessStatusCode();

            var stringResponse = client.GetStringAsync(uri.UriParameters).Result;
            
            Console.WriteLine(stringResponse);



        }
    }
}
