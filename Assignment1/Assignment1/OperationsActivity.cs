using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Text;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using System;



namespace Assignment1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class OperationsActivity : AppCompatActivity
    {

        EditText websiteTxt, dialText, sendMailText, locationText, mNumberText, messageText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_operations);

            init();

        }



        public void init()
        {

            websiteTxt = FindViewById<EditText>(Resource.Id.websiteText);
            dialText = FindViewById<EditText>(Resource.Id.dialText);
            sendMailText = FindViewById<EditText>(Resource.Id.sendMailText);
            locationText = FindViewById<EditText>(Resource.Id.locationText);
            mNumberText = FindViewById<EditText>(Resource.Id.mNumberText);
            messageText = FindViewById<EditText>(Resource.Id.messageText);

            Button websiteBtn = FindViewById<Button>(Resource.Id.websiteBtn);
            websiteBtn.Click += OpenWebsite;

            Button dialBtn = FindViewById<Button>(Resource.Id.dialBtn);
            dialBtn.Click += DialPhone;

            Button sendMailBtn = FindViewById<Button>(Resource.Id.sendMailBtn);
            sendMailBtn.Click += SendMail;

            Button locationBtn = FindViewById<Button>(Resource.Id.locationBtn);
            locationBtn.Click += OpenLocation;

            Button messageBtn = FindViewById<Button>(Resource.Id.messageBtn);
            messageBtn.Click += SendMessage;
        }

        private void OpenWebsite(object sender, EventArgs eventArgs)
        {
            try
            {
                var intent = new Intent();
                intent.SetAction(Intent.ActionView);
                intent.SetData(Android.Net.Uri.Parse(websiteTxt.Text.Trim()));
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Short).Show();
            }

           
        }

        private void DialPhone(object sender, EventArgs eventArgs)
        {
            try
            {
                string tel = "tel:" + dialText.Text.Trim();
                var uri = Android.Net.Uri.Parse(tel);
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Short).Show();
            }
            
        }


        private void SendMail(object sender, EventArgs eventArgs)
        {
            try
            {
                var email = new Intent(Android.Content.Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] {
                sendMailText.Text.Trim()
                });

                email.SetType("message/rfc822");
                StartActivity(email);
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Short).Show();
            }
            
        }

        private void OpenLocation(object sender, EventArgs eventArgs)
        {
            try
            {
                string searchText = locationText.Text.Replace(" ", "+");
                string map = "geo:0,0?q=" + searchText;
                Toast.MakeText(Application.Context, map, ToastLength.Short).Show();
                var geoUri = Android.Net.Uri.Parse(map);
                var mapIntent = new Intent(Intent.ActionView, geoUri);
                StartActivity(mapIntent);
            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Short).Show();
            }
            
        }

        private void SendMessage(object sender, EventArgs eventArgs)
        {
            try
            {
                if (!TextUtils.IsEmpty(mNumberText.Text.Trim()) && !TextUtils.IsEmpty(messageText.Text.Trim()))
                {
                    string tel = mNumberText.Text;
                    string message = messageText.Text;

                    SmsManager.Default.SendTextMessage(tel, null, message, null, null);

                    Toast.MakeText(Application.Context, "Your message has been sent", ToastLength.Short).Show();
                }
                 


            }
            catch (Exception ex)
            {
                Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Short).Show();
            }

        }



    }
}