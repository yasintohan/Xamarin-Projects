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
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ExpensesApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            GetCurrencies();
            InitializeComponent();

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
                await Navigation.PushModalAsync(new SettingsPage(), true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        async void GetCurrencies()
        {
            
            var content = await CurrencyService.ServiceClientInstance.GetCurrencyAsync();

            if(content != null)
            {
                Preferences.Set("EUR_TRY", content.EUR_TRY);
                Preferences.Set("GBP_TRY", content.GBP_TRY);
                Preferences.Set("USD_TRY", content.USD_TRY);
            } else if(!string.IsNullOrEmpty(Preferences.Get("EUR_TRY", "")) && !string.IsNullOrEmpty(Preferences.Get("GBP_TRY", "")) && !string.IsNullOrEmpty(Preferences.Get("USD_TRY", ""))) {
                Preferences.Set("EUR_TRY", 10);
                Preferences.Set("GBP_TRY", 12);
                Preferences.Set("USD_TRY", 8);
            }
                

        }

    }
}
