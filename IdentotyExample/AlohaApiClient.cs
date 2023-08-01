using IdentotyExample.Models.Dto;
using System.Net.Http.Headers;

namespace IdentotyExample
{
    public class AlohaApiClient
    {
        private readonly HttpClient _httpClient;
        public AlohaApiClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.alohaorderonline.com")
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void AddDefaultRequestHeaders(Action<HttpRequestHeaders> action) {
            action?.Invoke(_httpClient.DefaultRequestHeaders);
        }
        

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