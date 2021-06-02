using ExpensesApp.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddingPage : ContentPage
    {

        private double _pageHeight;
        public AddingPage()
        {
            InitializeComponent();
            setupPickers();
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

        private async void addBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!titleEntry.Text.Equals("") && !costEntry.Text.Equals(""))
                {
                    FirebaseClient fc = new FirebaseClient("https://xamarin-expense-app-default-rtdb.firebaseio.com/");
                    var result = await fc
                     .Child("Expences")
                     .Child(Preferences.Get("MyFirebaseId", ""))
                     .PostAsync(new ExpenseModel() { Date = DateTime.Now, Title = titleEntry.Text, Cost = costEntry.Text, Type = typePicker.Items[typePicker.SelectedIndex], Currency = currencyPicker.Items[currencyPicker.SelectedIndex] });
                    titleEntry.Text = "";
                    costEntry.Text = "";
                    await App.Current.MainPage.DisplayAlert("Alert", "Succesfully added", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }

        }

        private void setupPickers()
        {
            typePicker.Items.Add("Bill");
            typePicker.Items.Add("Rent");
            typePicker.Items.Add("Other");
            typePicker.SelectedIndex = 0;

            currencyPicker.Items.Add("TRY");
            currencyPicker.Items.Add("USD");
            currencyPicker.Items.Add("EUR");
            currencyPicker.Items.Add("GBP");
            currencyPicker.SelectedIndex = 0;
        }
    }
}