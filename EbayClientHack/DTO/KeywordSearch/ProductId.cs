using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayClientHack.DTO.KeywordSearch
{
    public class ProductId
    {
        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }
    }
}
