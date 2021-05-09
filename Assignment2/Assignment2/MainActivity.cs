using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Widget;
using System.Collections.Generic;
using AndroidX.Fragment.App;
using Android.App;
using Assignment2.Fragments;

namespace Assignment2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        ListView lstViewData;
        List<Person> listSource = new List<Person>();
        DBHelper db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var fragmentContainer = FindViewById<FrameLayout>(Resource.Id.fragmentContrainer);
            var fragTrans = FragmentManager.BeginTransaction();
            fragTrans.Replace(Resource.Id.fragmentContrainer, new ListViewFragment());
            fragTrans.Commit();

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.addfab);
            fab.Click += FabOnClick;

            FloatingActionButton listfab = FindViewById<FloatingActionButton>(Resource.Id.listfab);
            listfab.Click += ListFabOnClick;


           


        }

        private void LoadData()
        {
            listSource = db.selectTable();
            var adapter = new LvAdapter(this, listSource);
            lstViewData.Adapter = adapter;
        }


        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            var fragmentContainer = FindViewById<FrameLayout>(Resource.Id.fragmentContrainer);
            var fragTrans = FragmentManager.BeginTransaction();
            fragTrans.Replace(Resource.Id.fragmentContrainer, new CrudFragment());
            fragTrans.Commit();
        }
        private void ListFabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
           
            var fragmentContainer = FindViewById<FrameLayout>(Resource.Id.fragmentContrainer);
            var fragTrans = FragmentManager.BeginTransaction();
            fragTrans.Replace(Resource.Id.fragmentContrainer, new ListViewFragment());
            fragTrans.Commit();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
