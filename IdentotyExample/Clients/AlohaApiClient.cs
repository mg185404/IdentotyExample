using IdentotyExample.Enums;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static IdentotyExample.Enums.Enums;

namespace IdentotyExample.Clients
{
    public class AlohaApiClient : IAlohaApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AlohaApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient _httpClient { get => _httpClientFactory.CreateClient("AlohaApiClient"); }

        public async Task<Root> GetNearbySearchDesirialized(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true,
            bool includeAllSites = false, int offset = 0, int limit = 5)
        {
            try
            {
                var urlBuilder = new StringBuilder($"v1/NearbySites/{searchTerm}?getNearbySitesForFirstGeocodeResult={getNearbySitesForFirstGeocodeResult}&includeAllSites={includeAllSites}&offset={offset}&limit={limit}");
                string url = urlBuilder.ToString();
                string endpoint = $"GET {url}";

                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonData = await response.Content.ReadAsStringAsync();
                var responseDesirialized = System.Text.Json.JsonSerializer.Deserialize<Root>(jsonData);

                return responseDesirialized;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        public async Task<List<RootLL>> GetNearbySearchByCoordinateDesirialized(double latitude = 44.8125, double longitude = 20.4612, string? orderMode = null,
           int offset = 0, int limit = 5, bool includeAllSites = false, string? companyCode = null)
        {
            try
            {
                var urlBuilder = new StringBuilder($"v1/NearbySites/{latitude}/{longitude}?&offset={offset}&limit={limit}&includeAllSites={includeAllSites}");
                if (orderMode != null)
                    urlBuilder.Append($"&orderMode={orderMode}");
                if (companyCode != null)
                    urlBuilder.Append($"&companyCode={companyCode}");
                string url = urlBuilder.ToString();

                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonData = await response.Content.ReadAsStringAsync();
                var responseDesirialized = System.Text.Json.JsonSerializer.Deserialize<List<RootLL>>(jsonData);
                return responseDesirialized;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        public async Task<RootMenus> GetMenusDesirialized(int siteId, bool includeInvisible = false, OrderModeType? orderMode = null, DateTime? promiseTime = null)
        {
            try
            {
                var urlBuilder = new StringBuilder($"v1/Menus/{siteId}?includeInvisible={includeInvisible}");
                if (orderMode != null)
                    urlBuilder.Append($"&orderMode={orderMode}");
                if (promiseTime != null)
                    urlBuilder.Append($"&promiseTime={promiseTime}");
                string url = urlBuilder.ToString();

                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonData = await response.Content.ReadAsStringAsync();
                var responseDesirialized = System.Text.Json.JsonSerializer.Deserialize<RootMenus>(jsonData);
                return responseDesirialized;

            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        public async Task<DateTime> GetTimeDesirialized(int siteId, OrderModeType orderMode, bool noCache = false)
        {
            try
            {
                var urlBuilder = new StringBuilder($"v1/Times/{siteId}/{orderMode}?noCache={noCache}");
                string url = urlBuilder.ToString();



                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonData = await response.Content.ReadAsStringAsync();
                var responseDesirialized = System.Text.Json.JsonSerializer.Deserialize<DateTime>(jsonData);
                return responseDesirialized;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        public async Task<RootOrder> PutOrder(Order order, int siteId, bool verbose = false)
        {
            string url = $"v1/Orders/{siteId}?verbose={verbose}";
            var body = System.Text.Json.JsonSerializer.Serialize<Order>(order);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            string serializedJson = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            RootOrder rootOrder = System.Text.Json.JsonSerializer.Deserialize<RootOrder>(serializedJson);
            return rootOrder;
        }

    }
}