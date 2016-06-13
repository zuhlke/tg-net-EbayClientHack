using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayClientHack.DTO.ProductSearch
{
    public class ProductSearchResult
    {
        [JsonProperty(PropertyName = "ItemArray")]
        public ProductSearchItemArray ItemArray { get; set; }
    }
}
