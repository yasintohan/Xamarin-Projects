using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{

		public string APIkey = "AIzaSyDR6i14IaHpMZACjSf-ICBwpUmyCpC3DIo";

		public LoginPage ()
		{
			InitializeComponent ();
		}

		async void Handle_Tapped(object sender, System.EventArgs e)
		{
			try
			{
				await Navigation.PushModalAsync(new RegisterPage(), true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        private async void loginBtn_Clicked(object sender, EventArgs e)
        {
			var authProvider = new FirebaseAuthProvider(new FirebaseConfig(APIkey));
			try
			{
				var auth = await authProvider.SignInWithEmailAndPasswordAsync(loginmailEntry.Text, loginpasswordEntry.Text);
				var content = await auth.GetFreshAuthAsync();
				var serializedcontnet = JsonConvert.SerializeObject(content);
				Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
				Preferences.Set("MyFirebaseId", content.User.LocalId);
				App.Current.MainPage = new MainPage();
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
			}
		}
    }
}