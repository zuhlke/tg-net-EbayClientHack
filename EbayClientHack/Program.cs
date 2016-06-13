using EbayClientHack.DTO.KeywordSearch;
using EbayClientHack.DTO.ProductSearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EbayClientHack
{
    class Program
    {
        private const string AppId = "XXXXXXXXXXXXXXXXX";
        private const string BaseUrl = "http://open.api.sandbox.ebay.com/shopping";

        static void Main(string[] args)
        {
            //See http://developer.ebay.com/DevZone/Shopping/docs/CallRef/FindProducts.html
            //Service endpoints: http://developer.ebay.com/Devzone/guides/ebayfeatures/Basics/Call-RoutingRequest.html

            var kwsQueryParams = GetKeywordSearchQueryParams("Harry Potter");
            var kwsResultRaw = CallApi(kwsQueryParams);
            var kwsResult = JsonConvert.DeserializeObject<KeywordSearchResult>(kwsResultRaw);

            ProductId prodId = kwsResult.Products[0].ProductIds[0];

            var pQueryParams = GetProductSearchQueryParams(prodId.Value, prodId.Type);
            var pResultRaw = CallApi(pQueryParams);
            var pResult = JsonConvert.DeserializeObject<ProductSearchResult>(pResultRaw);

            decimal price = pResult.ItemArray.Items[0].CurrentPrice.Value;
        }

        private static string CallApi(Dictionary<string, string> queryParams)
        {
            using (var client = new WebClient())
            {
                var escapedParams = queryParams
                .Select(kvp => new { k = WebUtility.UrlEncode(kvp.Key), v = WebUtility.UrlEncode(kvp.Value) })
                .Select(kvp => string.Format("{0}={1}", kvp.k, kvp.v));

                client.BaseAddress = BaseUrl;

                return client.DownloadString("?" + string.Join("&", escapedParams));
            }
        }

        private static Dictionary<string, string> GetKeywordSearchQueryParams(string queryKeywords)
        {
            var qParams = GetCommonQueryParams();
            qParams["QueryKeywords"] = queryKeywords;
            return qParams;
        }

        private static Dictionary<string, string> GetProductSearchQueryParams(string productId, string productIdType)
        {
            var qParams = GetCommonQueryParams();
            qParams["ProductID.Value"] = productId;
            qParams["ProductID.type"] = productIdType;
            qParams["IncludeSelector"] = "Details";
            return qParams;
        }

        private static Dictionary<string, string> GetCommonQueryParams()
        {
            return new Dictionary<string, string>
            {
                {"appid", AppId },
                {"callname", "FindProducts" },
                {"responseencoding", "JSON" },
                {"AvailableItemsOnly", "true" },
                {"HideDuplicateItems", "true" },
                {"MaxEntries", "20" },
                {"PageNumber", "1" },
                {"ProductSort", "Popularity" },
                {"version", "957" }
            };
        }
    }
}
