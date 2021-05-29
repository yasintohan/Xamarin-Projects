using ExpensesApp.CurrencyApi;
using ExpensesApp.Models;
using ExpensesApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpensesApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetCurrencies();
        }

        async void Handle_ItemTapped(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
            {
                return;
            }

           ((CollectionView)sender).SelectedItem = null;
            var selected = (e.CurrentSelection?.First() as ExpenseModel);
            await Navigation.PushModalAsync(new DetailPage(selected), true);
        }

        async void OnImageAddTapped(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PushModalAsync(new AddingPage(), true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        async void OnImageSettingsTapped(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PushModalAsync(new LoginPage(), true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        async void GetCurrencies()
        {
            /*
            var httpClient = new HttpClient();
            var resultJson = await httpClient.GetStringAsync("https://api.ratesapi.io/api/latest");

            nameLabel.Text = resultJson;

            var resultCurrencies = JsonConvert.DeserializeObject<Currency>(resultJson);

            nameLabel.Text = resultCurrencies.Base;
            */

            var content = await CurrencyService.ServiceClientInstance.GetCurrencyAsync();

            if(content != null && !string.IsNullOrEmpty(content.Base))
            {
                nameLabel.Text = content.Base;
            } else
            {
               // await App.Current.MainPage.DisplayAlert("alert", "deneme", "ok");
            }
                

        }

    }
}
