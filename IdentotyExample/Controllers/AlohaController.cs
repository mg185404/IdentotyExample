using IdentotyExample.Enums;
using IdentotyExample.Models;
using IdentotyExample.Models.Dto;
using Microsoft.AspNet.SignalR.Client.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace IdentotyExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlohaController : ControllerBase
    {
        private readonly AlohaApiClient _client;
        private string credentials;


        public AlohaController()
        {
            _client = new AlohaApiClient();
            string username = "api-demo@ds.com";
            string password = "DigitalNCRDigital123@";
            credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));

            _client.AddDefaultRequestHeaders(headers =>
            {
                headers.Add("X-Api-CompanyCode", "DLEC001");
                headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            });
        }


        [HttpGet]
        [Route("NearbySearch")]
        public async Task<ActionResult> GetNearbySearch(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true,
            bool includeAllSites = false, int offset = 0, int limit = 5)
        {

            try
            {
                var result = await _client.GetAsync($"v1/NearbySites/{searchTerm}?getNearbySitesForFirstGeocodeResult={getNearbySitesForFirstGeocodeResult}&includeAllSites={includeAllSites}&offset={offset}&limit={limit}");
                var nearbySite = JsonSerializer.Deserialize<OutNearbySearch>(result);
                return Ok(result);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("SearchByCoordinate")]
        public async Task<ActionResult> GetNearbySearchByCoordinate(double latitude = 44.8125, double longitude = 20.4612, string orderMode = "Pickup",
            int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "DLEC001")
        {
            try
            {
                var result = await _client.GetAsync($"v1/NearbySites/{latitude}/{longitude}?orderMode={orderMode}&offset={offset}&limit={limit}&includeAllSites={includeAllSites}&companyCode={companyCode}");
                List<OutNearbySitesByCoordinate> sites = JsonSerializer.Deserialize<List<OutNearbySitesByCoordinate>>(result);
                return Ok(result);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("GetMenusBySiteId")]
        public async Task<ActionResult> GetMenusBySiteId(int siteId, OrderModeType orderMode, DateTime promiseTime, bool includeInvisible = false)
        {
            try
            {
                promiseTime = DateTime.Now.AddHours(1);
                var result = await _client.GetAsync($"v1/Menus/{siteId}?promiseTime={promiseTime}&includeInvisible={includeInvisible}&orderMode={orderMode}");
                var root = JsonSerializer.Deserialize<OutMenus>(result);
                return Ok(result);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetTimeBySiteId")]
        public async Task<ActionResult> GetTimesBySiteId(int siteId, OrderModeType orderMode, bool noCache = false)
        {
            try
            {
                var result = await _client.GetAsync($"v1/Times/{siteId}/{orderMode}?noCache={noCache}");
                return Ok(result);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }




        private InOrder order = new InOrder
        {
            SiteId = 1,
            OrderId = null,
            PromiseDateTime = DateTime.Now.AddHours(1),
            OrderMode = OrderModeType.Pickup,
            PaymentMode = PaymentMode.PaidOnline,
            Customer = new OrderCustomer
            {
                EMail = "proba@gmail.com",
                FirstName = "Test",
                LastName = "Test",
            }
        };


        [HttpPut]
        [Route("UpsertOrder")]
        public async Task<ActionResult> UpsertOrder(int siteId, bool verbose = false)
        {
            try
            {
                //order.SiteId = inOrder.SiteId;
                //order.OrderMode = inOrder.OrderMode;
                //order.OrderId = inOrder.OrderId;
                //order.PromiseDateTime = inOrder.PromiseDateTime;
                //order.PaymentMode = inOrder.PaymentMode;
                //order.OrderCustomer = inOrder.OrderCustomer;


                //inOrder.siteid = order.siteid;
                //inOrder.ordermode = order.ordermode;
                //inOrder.orderid = order.orderid;
                //inOrder.promisedatetime = order.promisedatetime;
                //inOrder.paymentmode = order.paymentmode;
                //inOrder.ordercustomer = order.ordercustomer;

                var result = CreateInOrder();

                string jsonData = JsonSerializer.Serialize(result);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var result2 = await _client.PutAsync($"v1/Orders/{siteId}", content);
                return Ok(result2);

            }
            catch (HttpRequestException)
            {
                throw;
            }
        }


        private InOrder CreateInOrder()
        {

            InOrder result = new InOrder();

            result.SiteId = 1;
            result.PromiseDateTime = new DateTime(2023,8,31);
            result.OrderMode = OrderModeType.Pickup;
            result.Channel = "Unknown";
            result.PaymentMode = PaymentMode.PaymentDeferred;
            result.ComboItems = new List<ComboItem>();
            result.Guests = new List<Guest>();
            result.Customer = new OrderCustomer
            {
                id = "2",
                EMail = "Test@gamil.com",
                FirstName = "Test",
                LastName = "Test"
            };
            result.LineItems = new List<InOrderLineItem>
            {
                new InOrderLineItem
                {
                 SalesItemId = 40067,
                 MenuItemId = 30008
                }
            };
            return result;
        }



       




    }
}
