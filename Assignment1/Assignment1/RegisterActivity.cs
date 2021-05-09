using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class RegisterActivity : AppCompatActivity
    {
        EditText nameSurnameTxt, ageTxt, emailTxt, passTxt;


        private ISharedPreferences mSharedPrefs;
        private ISharedPreferencesEditor mPrefsEditor;
        private Context mContext;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_register);

            init();

            this.mContext = Application.Context;
            mSharedPrefs = mContext.GetSharedPreferences("UsersInfo", FileCreationMode.Private);
            mPrefsEditor = mSharedPrefs.Edit();

        }

        public void init()
        {
            nameSurnameTxt = FindViewById<EditText>(Resource.Id.textPersonName);
            ageTxt = FindViewById<EditText>(Resource.Id.textAge);
            emailTxt = FindViewById<EditText>(Resource.Id.textEmailAddress);
            passTxt = FindViewById<EditText>(Resource.Id.textPassword);

            Button registerBtn = FindViewById<Button>(Resource.Id.register);
            registerBtn.Click += RegisterOnClick;
        }

        public int userCount()
        {
            int mInt = mSharedPrefs.GetInt("user_count", 0);
            return mInt;
        }

        private void RegisterOnClick(object sender, EventArgs eventArgs)
        {
            if(!TextUtils.IsEmpty(nameSurnameTxt.Text.Trim()) && !TextUtils.IsEmpty(ageTxt.Text.Trim()) && !TextUtils.IsEmpty(emailTxt.Text.Trim()))
            {
                createUser(nameSurnameTxt.Text.Trim(), Int32.Parse(ageTxt.Text), emailTxt.Text.Trim(), passTxt.Text.Trim());
            }
        }



        public void createUser(string name, int age, string mail, string pass)
        {
            int count = userCount() + 1;
            string NAME_KEY = "name" + count;
            string AGE_KEY = "age" + count;
            string MAIL_KEY = "mail" + count;
            string PASS_KEY = "pass" + count;
            string COUNT_KEY = "user_count";

            mPrefsEditor.PutString(NAME_KEY, name);
            mPrefsEditor.PutInt(AGE_KEY, age);
            mPrefsEditor.PutString(MAIL_KEY, mail);
            mPrefsEditor.PutString(PASS_KEY, pass);
            mPrefsEditor.PutInt(COUNT_KEY, count);
            mPrefsEditor.Apply();


            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }



    }
}