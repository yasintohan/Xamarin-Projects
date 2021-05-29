﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ExpensesApp.CurrencyApi
{
    public class Rates
    {
        [JsonProperty("GBP")]
        public double GBP { get; set; }

        [JsonProperty("HKD")]
        public double HKD { get; set; }

        [JsonProperty("IDR")]
        public double IDR { get; set; }

        [JsonProperty("ILS")]
        public double ILS { get; set; }

        [JsonProperty("DKK")]
        public double DKK { get; set; }

        [JsonProperty("INR")]
        public double INR { get; set; }

        [JsonProperty("CHF")]
        public double CHF { get; set; }

        [JsonProperty("MXN")]
        public double MXN { get; set; }

        [JsonProperty("CZK")]
        public double CZK { get; set; }

        [JsonProperty("SGD")]
        public double SGD { get; set; }

        [JsonProperty("THB")]
        public double THB { get; set; }

        [JsonProperty("HRK")]
        public double HRK { get; set; }

        [JsonProperty("MYR")]
        public double MYR { get; set; }

        [JsonProperty("NOK")]
        public double NOK { get; set; }

        [JsonProperty("CNY")]
        public double CNY { get; set; }

        [JsonProperty("BGN")]
        public double BGN { get; set; }

        [JsonProperty("PHP")]
        public double PHP { get; set; }

        [JsonProperty("SEK")]
        public double SEK { get; set; }

        [JsonProperty("PLN")]
        public double PLN { get; set; }

        [JsonProperty("ZAR")]
        public double ZAR { get; set; }

        [JsonProperty("CAD")]
        public double CAD { get; set; }

        [JsonProperty("ISK")]
        public double ISK { get; set; }

        [JsonProperty("BRL")]
        public double BRL { get; set; }

        [JsonProperty("RON")]
        public double RON { get; set; }

        [JsonProperty("NZD")]
        public double NZD { get; set; }

        [JsonProperty("TRY")]
        public double TRY { get; set; }

        [JsonProperty("JPY")]
        public double JPY { get; set; }

        [JsonProperty("RUB")]
        public double RUB { get; set; }

        [JsonProperty("KRW")]
        public double KRW { get; set; }

        [JsonProperty("USD")]
        public double USD { get; set; }

        [JsonProperty("HUF")]
        public double HUF { get; set; }

        [JsonProperty("AUD")]
        public double AUD { get; set; }
    }

    public class Currency
    {
        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("rates")]
        public Rates Rates { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
