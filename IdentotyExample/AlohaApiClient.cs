using IdentotyExample.Models.Dto;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace IdentotyExample
{
    public class AlohaApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AlohaApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient _httpClient { get => _httpClientFactory.CreateClient("AlohaApiClient"); }

        public async Task<string> GetAsync(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        public async Task<string> PostAsync(string endpoint,HttpContent content)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(endpoint,content);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        public async Task<string> PutAsync(string endpoint, HttpContent content)
        {
            HttpResponseMessage response = await _httpClient.PutAsync(endpoint, content);
            //response.EnsureSuccessStatusCode();

            var variable = await response.Content.ReadAsStringAsync();
            return variable;
        }
    }
}