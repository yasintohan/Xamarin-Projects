using Firebase.Auth;
using Newtonsoft.Json;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public string APIkey = "AIzaSyDR6i14IaHpMZACjSf-ICBwpUmyCpC3DIo";
        private double _pageHeight;
        public SettingsPage()
        {
            InitializeComponent();
            GetProfileInformationAndRefreshToken();
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

        async void Logout_Tapped(object sender, System.EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            Preferences.Remove("MyFirebaseId");
            Preferences.Remove("MyFirebaseUser");
            App.Current.MainPage = new LoginPage();
        }


        async private void GetProfileInformationAndRefreshToken()
        {
            
            try
            {
                var savedfirebaseauth = JsonConvert.DeserializeObject<Models.User>(Preferences.Get("MyFirebaseUser", ""));
                nameLabel.Text = savedfirebaseauth.firstName;
                lnamelLabel.Text = savedfirebaseauth.lastName;
                genderLabel.Text = savedfirebaseauth.Gender;
                if (savedfirebaseauth.Gender.Equals("Male") || savedfirebaseauth.Gender.Equals("Female"))
                    genderImage.Source = savedfirebaseauth.Gender;
                else
                    genderImage.Source = "Gender";
                mailLabel.Text = savedfirebaseauth.email;
                /*
                var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);

                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                Preferences.Set("MyFirebaseId", RefreshedContent.User.LocalId);
                mailLabel.Text = savedfirebaseauth.User.FirstName;
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Oh no !  Token expired", "OK");
            }



        }


    }
}