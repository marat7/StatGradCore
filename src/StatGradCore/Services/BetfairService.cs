using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatGradCore.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace StatGradCore.Services
{
    public class BetfairService : IBetfairClient
    {
        public string SessionToken { get; set; }
        public string EndPoint { get; private set; }
        private static readonly IDictionary<string, Type> operationReturnTypeMap = new Dictionary<string, Type>();
        public const string APPKEY_HEADER = "X-Application";
        public const string SESSION_TOKEN_HEADER = "X-Authentication";

        private static readonly string LIST_EVENT_TYPES_METHOD = "listEventTypes";
        private static readonly string LIST_MARKET_CATALOGUE_METHOD = "listMarketCatalogue";
        private static readonly string LIST_MARKET_TYPES_METHOD = "listMarketTypes";
        private static readonly string LIST_MARKET_BOOK_METHOD = "listMarketBook";
        private static readonly string PLACE_ORDERS_METHOD = "placeOrders";
        private static readonly string LIST_MARKET_PROFIT_AND_LOST_METHOD = "listMarketProfitAndLoss";
        private static readonly string LIST_CURRENT_ORDERS_METHOD = "listCurrentOrders";
        private static readonly string LIST_CLEARED_ORDERS_METHOD = "listClearedOrders";
        private static readonly string CANCEL_ORDERS_METHOD = "cancelOrders";
        private static readonly string REPLACE_ORDERS_METHOD = "replaceOrders";
        private static readonly string UPDATE_ORDERS_METHOD = "updateOrders";
        private static readonly String FILTER = "filter";
        private static readonly String LOCALE = "locale";
        private static readonly String CURRENCY_CODE = "currencyCode";
        private static readonly String MARKET_PROJECTION = "marketProjection";
        private static readonly String MATCH_PROJECTION = "matchProjection";
        private static readonly String ORDER_PROJECTION = "orderProjection";
        private static readonly String PRICE_PROJECTION = "priceProjection";
        private static readonly String SORT = "sort";
        private static readonly String MAX_RESULTS = "maxResults";
        private static readonly String MARKET_IDS = "marketIds";
        private static readonly String MARKET_ID = "marketId";
        private static readonly String INSTRUCTIONS = "instructions";
        private static readonly String CUSTOMER_REFERENCE = "customerRef";
        private static readonly string INCLUDE_SETTLED_BETS = "includeSettledBets";
        private static readonly String INCLUDE_BSP_BETS = "includeBspBets";
        private static readonly String NET_OF_COMMISSION = "netOfCommission";
        private static readonly String BET_IDS = "betIds";
        private static readonly String PLACED_DATE_RANGE = "placedDateRange";
        private static readonly String ORDER_BY = "orderBy";
        private static readonly String SORT_DIR = "sortDir";
        private static readonly String FROM_RECORD = "fromRecord";
        private static readonly String RECORD_COUNT = "recordCount";
        private static readonly string BET_STATUS = "betStatus";
        private static readonly string EVENT_TYPE_IDS = "eventTypeIds";
        private static readonly string EVENT_IDS = "eventIds";
        private static readonly string RUNNER_IDS = "runnerIds";
        private static readonly string SIDE = "side";
        private static readonly string SETTLED_DATE_RANGE = "settledDateRange";
        private static readonly string GROUP_BY = "groupBy";
        private static readonly string INCLUDE_ITEM_DESCRIPTION = "includeItemDescription";

        public async Task<LoginResponse> Login(string username, string password)
        {
            var payload = String.Format("username={0}&password={1}", username, password);
            var client = new HttpClient();
            client.DefaultRequestHeaders
                .Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation(APPKEY_HEADER, "9HsXy5awsbJ3U7so");
            var loginResponse = await client.PostAsync(new Uri("https://identitysso.betfair.com/api/login"),
                new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded"));
            var responseString = await loginResponse.Content.ReadAsStringAsync();
            var loginResp = JsonConvert.DeserializeObject<LoginResponse>(responseString);
            this.SessionToken = loginResp.Token;
            return loginResp;
        }

        public async Task<T> Invoke<T>(string method, IDictionary<string, object> args = null)
        {
            if (method == null)
                throw new ArgumentNullException("method");
            if (method.Length == 0)
                throw new ArgumentException(null, "method");

            var postData = JsonConvert.SerializeObject(args) + "}";

            var restEndPoint = "https://api.betfair.com/exchange/betting/rest/v1.0/" + method + "/";

            var client = new HttpClient();
            client.DefaultRequestHeaders
                .Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.TryAddWithoutValidation(APPKEY_HEADER, "9HsXy5awsbJ3U7so");
            if (SessionToken == null)
                throw new ArgumentNullException("sessionToken");
            if (SessionToken.Length == 0)
                throw new ArgumentException(null, "sessionToken");
            client.DefaultRequestHeaders.TryAddWithoutValidation(SESSION_TOKEN_HEADER, SessionToken);

            var response = await client.PostAsync(restEndPoint, new StringContent(postData, Encoding.UTF8, "application/json"));

            var respString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(respString);
        }

        public async Task<IList<EventTypeResult>> listEventTypes(MarketFilter marketFilter, string locale = null)
        {
            var args = new Dictionary<string, object>();
            args[FILTER] = marketFilter;
            args[LOCALE] = locale;
            return await Invoke<List<EventTypeResult>>(LIST_EVENT_TYPES_METHOD, args);
        }

        public Task<CancelExecutionReport> cancelOrders(string marketId, IList<CancelInstruction> instructions, string customerRef)
        {
            throw new NotImplementedException();
        }

        public Task<ClearedOrderSummaryReport> listClearedOrders(BetStatus betStatus, ISet<string> eventTypeIds = null, ISet<string> eventIds = null, ISet<string> marketIds = null, ISet<RunnerId> runnerIds = null, ISet<string> betIds = null, Side? side = default(Side?), TimeRange settledDateRange = null, GroupBy? groupBy = default(GroupBy?), bool? includeItemDescription = default(bool?), string locale = null, int? fromRecord = default(int?), int? recordCount = default(int?))
        {
            throw new NotImplementedException();
        }

        public Task<CurrentOrderSummaryReport> listCurrentOrders(ISet<string> betIds, ISet<string> marketIds, OrderProjection? orderProjection = default(OrderProjection?), TimeRange placedDateRange = null, OrderBy? orderBy = default(OrderBy?), SortDir? sortDir = default(SortDir?), int? fromRecord = default(int?), int? recordCount = default(int?))
        {
            throw new NotImplementedException();
        }

        

        public Task<IList<MarketBook>> listMarketBook(IList<string> marketIds, PriceProjection priceProjection, OrderProjection? orderProjection = default(OrderProjection?), MatchProjection? matchProjection = default(MatchProjection?), string currencyCode = null, string locale = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<MarketCatalogue>> listMarketCatalogue(MarketFilter marketFilter, ISet<MarketProjection> marketProjections, MarketSort marketSort, string maxResult = "1", string locale = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<MarketProfitAndLoss>> listMarketProfitAndLoss(IList<string> marketIds, bool includeSettledBets = false, bool includeBspBets = false, bool netOfCommission = false)
        {
            throw new NotImplementedException();
        }

        
        public Task<PlaceExecutionReport> placeOrders(string marketId, string customerRef, IList<PlaceInstruction> placeInstructions, string locale = null)
        {
            throw new NotImplementedException();
        }

        public Task<ReplaceExecutionReport> replaceOrders(string marketId, IList<ReplaceInstruction> instructions, string customerRef)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateExecutionReport> updateOrders(string marketId, IList<UpdateInstruction> instructions, string customerRef)
        {
            throw new NotImplementedException();
        }
    }
}
