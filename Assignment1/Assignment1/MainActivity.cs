using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using AndroidX.Core.App;

namespace Assignment1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        EditText emailTxt, passTxt;
        private ISharedPreferences mSharedPrefs;
        private ISharedPreferencesEditor mPrefsEditor;
        private Context mContext;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.SendSms }, 1);
            init();
            this.mContext = Application.Context;
            mSharedPrefs = mContext.GetSharedPreferences("UsersInfo", FileCreationMode.Private);
            mPrefsEditor = mSharedPrefs.Edit();


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void SignInOnClick(object sender, EventArgs eventArgs)
        {
            if (!TextUtils.IsEmpty(emailTxt.Text.Trim()))
            {
                for(int i = 1; i <= userCount(); i++)
                {
                    string MAIL_KEY = "mail" + i;
                    string PASS_KEY = "pass" + i;

                    if (emailTxt.Text.Equals(mSharedPrefs.GetString(MAIL_KEY, "loremipsum@mail.com")) && passTxt.Text.Equals(mSharedPrefs.GetString(PASS_KEY, "loremipsum"))) {
                        //logis success
                        var intent = new Intent(this, typeof(OperationsActivity));
                        StartActivity(intent);
                        
                    }

                }
            }
        }


        private void RegisterOnClick(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent);
        }

        public void init()
        {
           
            emailTxt = FindViewById<EditText>(Resource.Id.textEmailAddress);
            passTxt = FindViewById<EditText>(Resource.Id.textPassword);

            Button signInBtn = FindViewById<Button>(Resource.Id.sign_in);
            signInBtn.Click += SignInOnClick;

            Button registerBtn = FindViewById<Button>(Resource.Id.register);
            registerBtn.Click += RegisterOnClick;
        }

        public int userCount()
        {
            int mInt = mSharedPrefs.GetInt("user_count", 0);
            return mInt;
        }

        

    }
}