using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayClientHack.DTO.ProductSearch
{
    public class Price
    {
        [JsonProperty(PropertyName = "Value")]
        public decimal Value { get; set; }

        [JsonProperty(PropertyName = "CurrencyID")]
        public string CurrencyId { get; set; }
    }
}
