using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayClientHack.DTO.KeywordSearch
{
    public class KeywordSearchResult
    {
        [JsonProperty(PropertyName = "Product")]
        public List<Product> Products { get; set; }
    }
}
