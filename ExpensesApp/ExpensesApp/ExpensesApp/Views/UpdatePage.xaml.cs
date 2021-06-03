using ExpensesApp.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    
    public partial class UpdatePage : ContentPage
    {
        private double _pageHeight;
        private string ExpenseId;
        private ExpenseModel model;
        private FirebaseClient firebase;
        public UpdatePage(ExpenseModel model)
        {
            InitializeComponent();
            this.model = model;
            ExpenseId = model.ExpenseId;
            firebase = new FirebaseClient("https://xamarin-expense-app-default-rtdb.firebaseio.com/");
            getInformations();
        }


        private void setupPickers()
        {
            typePicker.Items.Add("Bill");
            typePicker.Items.Add("Rent");
            typePicker.Items.Add("Other");

            currencyPicker.Items.Add("TRY");
            currencyPicker.Items.Add("USD");
            currencyPicker.Items.Add("EUR");
            currencyPicker.Items.Add("GBP");
            
        }

        private async void getInformations()
        {
            setupPickers();
            model.ExpenseId = ExpenseId;
            titleEntry.Text = model.Title;
            costEntry.Text = model.Cost;
            typePicker.SelectedItem = model.Type;
            currencyPicker.SelectedItem = model.Currency;    
        }
        protected override async void OnAppearing()
        {
            await cakeDetail.TranslateTo(0, header.Y, 500, Easing.SinOut);
            await header.FadeTo(1);
            base.OnAppearing();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            _pageHeight = height;
            cakeDetail.TranslationY = _pageHeight * .65;
            header.FadeTo(0, 0);
            base.OnSizeAllocated(width, height);
        }

        async void Handle_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void updateBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!titleEntry.Text.Equals("") && !costEntry.Text.Equals(""))
                {
                    model.Title = titleEntry.Text;
                    model.Cost = costEntry.Text;
                    model.Type = typePicker.Items[typePicker.SelectedIndex];
                    model.Currency = currencyPicker.Items[currencyPicker.SelectedIndex];
                    await firebase
                     .Child("Expenses")
                     .Child(Preferences.Get("MyFirebaseId", ""))
                     .Child(ExpenseId).PutAsync(model);

                    await App.Current.MainPage.DisplayAlert("Alert", "Succesfully Updated", "OK");
                    await Navigation.PopModalAsync();
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}