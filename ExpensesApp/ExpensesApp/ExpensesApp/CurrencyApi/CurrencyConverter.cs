using System;
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

            baseRate = Convert.ToDouble(Preferences.Get(baseCurrency, 1.0));
            targetRate = Convert.ToDouble(Preferences.Get(targetCurrency, 1.0));

            

            convertedValue = value / baseRate * targetRate;


            return convertedValue;
        }


    }
}
