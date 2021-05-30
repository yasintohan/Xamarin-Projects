using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ExpensesApp.CurrencyApi
{
    
    public class Currency
    {
        [JsonProperty("EUR_TRY")]
        public string EUR_TRY { get; set; }

        [JsonProperty("USD_TRY")]
        public string USD_TRY { get; set; }

        [JsonProperty("GBP_TRY")]
        public string GBP_TRY { get; set; }

    }
}
