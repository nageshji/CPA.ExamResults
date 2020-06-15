using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CLA.ExamResults.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;
        public HttpService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://cpacodingchallenge.azurewebsites.net/api/");            
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
        }

        public HttpResponseMessage GetResponse(string url)
        {
            var request = new HttpRequestMessage(
               HttpMethod.Get,
               url);            
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
        }
    }
}
