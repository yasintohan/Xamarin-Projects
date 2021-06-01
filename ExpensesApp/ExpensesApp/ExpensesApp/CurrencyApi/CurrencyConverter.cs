using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ExpensesApp.CurrencyApi
{
    public class CurrencyConverter
    {


        public double Converter(string baseCurrency, string targetCurrency, double value)
        {
            double convertedValue = 0;
            double baseRate = 1;
            double targetRate = 8;

            
            switch (baseCurrency)
            {
                case "EUR":
                    baseRate = Convert.ToDouble(Preferences.Get("EUR_TRY", 10.0));
                    break;
                case "USD":
                    baseRate = Convert.ToDouble(Preferences.Get("USD_TRY", 8.0));
                    break;
                case "TRY":
                    baseRate = 1;
                    break;
                case "GBP":
                    baseRate = Convert.ToDouble(Preferences.Get("GBP_TRY", 12.0));
                    break;
                default:
                    baseRate = 1; 
                    break;
            }

            switch (targetCurrency)
            {
                case "EUR":
                    targetRate = Convert.ToDouble(Preferences.Get("EUR_TRY", 10.0));
                    break;
                case "USD":
                    targetRate = Convert.ToDouble(Preferences.Get("USD_TRY", 8.0));
                    break;
                case "TRY":
                    targetRate = 1;
                    break;
                case "GBP":
                    targetRate = Convert.ToDouble(Preferences.Get("GBP_TRY", 12.0));
                    break;
                default:
                    targetRate = 1;
                    break;
            }

            convertedValue = value * baseRate / targetRate;


            return convertedValue;
        }


    }
}
