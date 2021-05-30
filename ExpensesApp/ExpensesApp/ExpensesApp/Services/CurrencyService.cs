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
                var content = "";
                HttpClient myClient = new HttpClient();
                var uri = new Uri("https://free.currconv.com/api/v7/convert?q=EUR_TRY&compact=ultra&apiKey=39a34f884814db8f612d");
                var response = await myClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                    content = await response.Content.ReadAsStringAsync();
                uri = new Uri("https://free.currconv.com/api/v7/convert?q=USD_TRY&compact=ultra&apiKey=39a34f884814db8f612d");
                response = await myClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                    content += await response.Content.ReadAsStringAsync();
                uri = new Uri("https://free.currconv.com/api/v7/convert?q=GBP_TRY&compact=ultra&apiKey=39a34f884814db8f612d");
                response = await myClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                    content += await response.Content.ReadAsStringAsync();

                content = content.Replace("}{", " , ");
                var Item = JsonConvert.DeserializeObject<Currency>(content);
                return Item;

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Something went wrong. Please check Internet connection.", "ok");
                return null;
            }
        }


    }
}
