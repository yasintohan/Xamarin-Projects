using ExpensesApp.CurrencyApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ExpensesApp.Services
{
    class CurrencyService
    {

        private static CurrencyService _ServiceClientInstance;
        public static CurrencyService ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new CurrencyService();
                return _ServiceClientInstance;
            }
        }

        private JsonSerializer _serializer = new JsonSerializer();
        private HttpClient client;

        public CurrencyService()
        {
            client = new HttpClient();
        }


        public async Task<Currency> GetCurrencyAsync()
        {
            try
            {

                var uri = new Uri("http://api.ratesapi.io/api/latest");
                HttpClient myClient = new HttpClient();

                var response = await myClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var Item = JsonConvert.DeserializeObject<Currency>(content);
                    return Item;
                } else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("alert", ex.ToString(), "ok");
                return null;
            }
        }


    }
}
