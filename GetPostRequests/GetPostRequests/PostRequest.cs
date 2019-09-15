using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace GetPostRequests
{
    public class PostRequest
    {
        public PostRequest()
        {
        }
        public async void PostReq(IUriParams uri)
        {
            var client = new HttpClient() { BaseAddress = new Uri(uri.Uri) };

            var message = new Dictionary<string, string>
            {
                { "name", "Roman" },
                { "message", "Hello" }
            };

            using (var messageContent = new FormUrlEncodedContent(message))

            {
                client.DefaultRequestHeaders.Accept.Add(
                  new MediaTypeWithQualityHeaderValue("application/json"));


                var response = await client.PostAsync(uri.UriParameters, messageContent);

                response.EnsureSuccessStatusCode();

                var stringResponse = client.GetStringAsync(uri.UriParameters).Result;

                Console.WriteLine(stringResponse);
            }   
        }
    }
}
