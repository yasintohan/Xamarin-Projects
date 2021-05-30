using ExpensesApp.Models;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{

        private double _pageHeight;
        public string APIkey = "AIzaSyDR6i14IaHpMZACjSf-ICBwpUmyCpC3DIo";

        public RegisterPage ()
		{
			InitializeComponent ();
            genderPicker.Items.Add("Male");
            genderPicker.Items.Add("Female");
            genderPicker.Items.Add("Other");
            genderPicker.SelectedIndex = 0;
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

        private async void registerBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(APIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(mailEntry.Text, passwordEntry.Text);
                string gettoken = auth.FirebaseToken;


                FirebaseClient fc = new FirebaseClient("https://xamarin-expense-app-default-rtdb.firebaseio.com/");
                var result = await fc
                 .Child("Users")
                 .Child(auth.User.LocalId)
                 .PostAsync(new Models.User() { localId = auth.User.LocalId, firstName = nameEntry.Text, lastName = lnameEntry.Text, Gender = genderPicker.Items[genderPicker.SelectedIndex], email = mailEntry.Text });


                await App.Current.MainPage.DisplayAlert("Alert", gettoken, "Ok");
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

       
    }
}