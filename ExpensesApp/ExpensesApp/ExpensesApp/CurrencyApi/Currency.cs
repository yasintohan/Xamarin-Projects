using Newtonsoft.Json;

namespace ExpensesApp.CurrencyApi
{

    public class Rates
    {
        [JsonProperty("GBP")]
        public double GBP { get; set; }

        [JsonProperty("USD")]
        public double USD { get; set; }

        [JsonProperty("EUR")]
        public double EUR { get; set; }

        [JsonProperty("TRY")]
        public double TRY { get; set; }
        
    }

    public class Currency
    {
        [JsonProperty("base")]
        public string baseCurrency { get; set; }

        [JsonProperty("rates")]
        public Rates rates { get; set; }
    }

}
