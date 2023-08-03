using static IdentotyExample.Enums.Enums;

namespace IdentotyExample.Clients
{
    public interface IAlohaApiClient
    {
        Task<DateTime> GetTimeDesirialized(int siteId, OrderModeType orderMode, bool noCache = false);
        Task<RootOrder> PutOrder(Order order, int siteId, bool verbose = false);
        Task<RootMenus> GetMenusDesirialized(int siteId, bool includeInvisible = false, OrderModeType? orderMode = null, DateTime? promiseTime = null);
        Task<List<RootLL>> GetNearbySearchByCoordinateDesirialized(double latitude = 44.8125, double longitude = 20.4612, string? orderMode = null,
                   int offset = 0, int limit = 5, bool includeAllSites = false, string? companyCode = null);
        Task<Root> GetNearbySearchDesirialized(string searchTerm, bool getNearbySitesForFirstGeocodeResult = true,
            bool includeAllSites = false, int offset = 0, int limit = 5);
    }

}