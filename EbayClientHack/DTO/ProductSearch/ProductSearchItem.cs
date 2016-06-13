using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayClientHack.DTO.ProductSearch
{
    public class ProductSearchItem
    {
        [JsonProperty(PropertyName = "CurrentPrice")]
        public Price CurrentPrice { get; set; }
    }
}
