﻿using ExpensesApp.CurrencyApi;
using ExpensesApp.Models;
using ExpensesApp.Services;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ExpensesApp
{
    public partial class MainPage : ContentPage
    {

        private string baseCurrency = "TRY";

        public string BaseCurrency
        {
            get { return baseCurrency; }
            set { baseCurrency = value; }
        }

        public MainPage()
        {
            GetCurrencies();
            InitializeComponent();
            GetInformations();
            
        }


        private async void GetInformations()
        {
            try
            {
                double totalExpense = 0;

                FirebaseClient fc = new FirebaseClient("https://xamarin-expense-app-default-rtdb.firebaseio.com/");
                var GetExpenses = (await fc
                  .Child("Expences")
                  .Child(Preferences.Get("MyFirebaseId", ""))
                  .OnceAsync<ExpenseModel>()).Select(item => new ExpenseModel
                  {
                      Date = item.Object.Date,
                      Title = item.Object.Title,
                      Cost = item.Object.Cost,
                      Type = item.Object.Type,
                      Currency = item.Object.Currency
                  }).ToList().OrderByDescending(i => i.Date);

                CurrencyConverter currencyConverter = new CurrencyConverter();

                List<ExpenseModel> convertedList = new List<ExpenseModel>();

                foreach (ExpenseModel model in GetExpenses)
                {
                    ExpenseModel newModel = new ExpenseModel
                    {
                        Date = model.Date,
                        Title = model.Title,
                        Cost = Math.Round(currencyConverter.Converter(model.Currency, baseCurrency, Convert.ToDouble(model.Cost)), 2).ToString(),
                        Type = model.Type,
                        Currency = baseCurrency
                    };
                    totalExpense += currencyConverter.Converter(model.Currency, baseCurrency, Convert.ToDouble(model.Cost));
                    convertedList.Add(newModel);
                }
                expensesLabel.Text = Math.Round(totalExpense, 2) + " " + baseCurrency;
                CollectionViewExpense.ItemsSource = convertedList;


            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.ToString(), "OK");
            }

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




        async void GetCurrencies()
        {

            var content = await CurrencyService.ServiceClientInstance.GetCurrencyAsync();

            if (content != null)
            {
                Preferences.Set("EUR_TRY", content.EUR_TRY);
                Preferences.Set("GBP_TRY", content.GBP_TRY);
                Preferences.Set("USD_TRY", content.USD_TRY);
            }
            else if (!string.IsNullOrEmpty(Preferences.Get("EUR_TRY", "")) && !string.IsNullOrEmpty(Preferences.Get("GBP_TRY", "")) && !string.IsNullOrEmpty(Preferences.Get("USD_TRY", "")))
            {
                Preferences.Set("EUR_TRY", 10.0);
                Preferences.Set("GBP_TRY", 12.0);
                Preferences.Set("USD_TRY", 8.0);
            }


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

        async void OnImageRefreshTapped(object sender, EventArgs args)
        {
            GetInformations();
        }

        private void CurrencySelector_Tapped(object sender, EventArgs e)
        {
           
            var btn = (Frame)sender;
            switch (btn.ClassId)
            {
                case "TRYFrame":
                    BaseCurrency = "TRY";
                    ((Label)TRYFrame.Content).TextColor = Color.FromHex("#FB8500");
                    ((Label)USDFrame.Content).TextColor = Color.Black;
                    ((Label)EURFrame.Content).TextColor = Color.Black;
                    ((Label)GBPFrame.Content).TextColor = Color.Black;
                    break;

                case "USDFrame":
                    BaseCurrency = "USD";
                    ((Label)TRYFrame.Content).TextColor = Color.Black;
                    ((Label)USDFrame.Content).TextColor = Color.FromHex("#FB8500");
                    ((Label)EURFrame.Content).TextColor = Color.Black;
                    ((Label)GBPFrame.Content).TextColor = Color.Black;
                    break;

                case "EURFrame":
                    BaseCurrency = "EUR";
                    ((Label)TRYFrame.Content).TextColor = Color.Black;
                    ((Label)USDFrame.Content).TextColor = Color.Black;
                    ((Label)EURFrame.Content).TextColor = Color.FromHex("#FB8500");
                    ((Label)GBPFrame.Content).TextColor = Color.Black;
                    break;

                case "GBPFrame":
                    BaseCurrency = "GBP";
                    ((Label)TRYFrame.Content).TextColor = Color.Black;
                    ((Label)USDFrame.Content).TextColor = Color.Black;
                    ((Label)EURFrame.Content).TextColor = Color.Black;
                    ((Label)GBPFrame.Content).TextColor = Color.FromHex("#FB8500");
                    break;

                default:
                    break;
            }
            GetInformations();
        }
    }
}
