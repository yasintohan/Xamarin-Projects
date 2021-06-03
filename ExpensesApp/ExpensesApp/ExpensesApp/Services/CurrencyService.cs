using ExpensesApp.CurrencyApi;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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
                var content = "";
                HttpClient myClient = new HttpClient();
                var uri = new Uri("https://api.exchangerate.host/latest");
                var response = await myClient.GetAsync(uri);
                content = await response.Content.ReadAsStringAsync();
                var Item = JsonConvert.DeserializeObject<Currency>(content);
                return Item;

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.ToString(), "ok");
                return null;
            }
        }


    }
}
