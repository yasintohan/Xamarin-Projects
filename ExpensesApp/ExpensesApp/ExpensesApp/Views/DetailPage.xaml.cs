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
    public partial class DetailPage : ContentPage
    {

        private double _pageHeight;
        private ExpenseModel expenseModel;

        public DetailPage(ExpenseModel expenseModel)
        {
            this.expenseModel = expenseModel;
            InitializeComponent();
            typeImage.Source = expenseModel.Type;
            titlelabel.Text = expenseModel.Title;
            costlabel.Text = expenseModel.Cost;
            currencylabel.Text = expenseModel.Currency;
           
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

        private async void deleteBtn_Clicked(object sender, System.EventArgs e)
        {

            try
            {
                var answer = await DisplayAlert("Delete Message", "Do you wan't to delete the exoense?", "Yes", "No");
                if (answer)
                {
                    var firebase = new FirebaseClient("https://xamarin-expense-app-default-rtdb.firebaseio.com/");
                    await firebase.Child("Expenses").Child(Preferences.Get("MyFirebaseId", "")).Child(expenseModel.ExpenseId).DeleteAsync();
                    await Navigation.PopModalAsync();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }

           
            
           
        }
    }
}