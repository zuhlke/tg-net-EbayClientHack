using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayClientHack.DTO.KeywordSearch
{
    public class Product
    {
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "ProductID")]
        public List<ProductId> ProductIds { get; set; }
    }
}
