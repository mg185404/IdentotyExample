using IdentotyExample.Clients;
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
using static IdentotyExample.Enums.Enums;

namespace IdentotyExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlohaController : ControllerBase
    {
        private readonly AlohaApiClient _client;
        public AlohaController(AlohaApiClient client)
        {
            _client = client;
        }


        [HttpGet]
        [Route("NearbySearch")]
        public async Task<ActionResult> GetNearbySearch(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true,
            bool includeAllSites = false, int offset = 0, int limit = 5)
        {

            try
            {
                var result = await _client.GetNearbySearchDesirialized(searchTerm, getNearbySitesForFirstGeocodeResult, includeAllSites, offset, limit);
                return Ok(result);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("SearchByCoordinate")]
        public async Task<ActionResult> GetNearbySearchByCoordinate(double latitude = 44.8125, double longitude = 20.4612,
           int offset = 0, int limit = 5, bool includeAllSites = false, string? orderMode = null, string? companyCode = null)
        {
            try
            {
                var result = await _client.GetNearbySearchByCoordinateDesirialized(latitude, longitude, orderMode, offset, limit, includeAllSites, companyCode);
                return Ok(result);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("GetMenusBySiteId")]
        public async Task<ActionResult> GetMenusBySiteId(int siteId, bool includeInvisible = false, OrderModeType? orderMode = null, DateTime? promiseTime = null)
        {
            try
            {
                var result = await _client.GetMenusDesirialized(siteId, includeInvisible, orderMode, promiseTime);
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
                var result = await _client.GetTimeDesirialized(siteId, orderMode, noCache);
                return Ok(result);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }


        [HttpPut]
        [Route("UpsertOrder")]
        public async Task<ActionResult> UpsertOrder([FromBody] Order requst, int siteId, bool verbose = false)
        {
            try
            {
                var result = await _client.PutOrder(requst, siteId, verbose);
                return Ok(result);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }






        //private InOrder order = new InOrder
        //{
        //    SiteId = 1,
        //    OrderId = null,
        //    PromiseDateTime = DateTime.Now.AddHours(1),
        //    OrderMode = OrderModeType.Pickup,
        //    PaymentMode = PaymentMode.PaidOnline,
        //    Customer = new OrderCustomer
        //    {
        //        EMail = "proba@gmail.com",
        //        FirstName = "Test",
        //        LastName = "Test",
        //    }
        //};


        //private InOrder CreateInOrder()
        //{

        //    InOrder result = new InOrder();

        //    result.SiteId = 1;
        //    result.PromiseDateTime = new DateTime(2023, 8, 31);
        //    result.OrderMode = OrderModeType.Pickup;
        //    result.Channel = "Unknown";
        //    result.PaymentMode = PaymentMode.PaymentDeferred;
        //    result.ComboItems = new List<ComboItem>();
        //    result.Guests = new List<Guest>();
        //    result.Customer = new OrderCustomer
        //    {
        //        id = "2",
        //        EMail = "Test@gamil.com",
        //        FirstName = "Test",
        //        LastName = "Test"
        //    };
        //    result.LineItems = new List<InOrderLineItem>
        //    {
        //        new InOrderLineItem
        //        {
        //         SalesItemId = 40067,
        //         MenuItemId = 30008
        //        }
        //    };
        //    return result;
        //}








    }
}
