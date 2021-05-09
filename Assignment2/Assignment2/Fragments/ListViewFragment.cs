using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.App.ActionBar;

namespace Assignment2.Fragments
{
    [Obsolete]
    public class ListViewFragment : Fragment
    {

        ListView lstViewData;
        List<Person> listSource = new List<Person>();
        DBHelper db;
        View v;


     


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            v = inflater.Inflate(Resource.Layout.ListFragment, container, false);


            //Create Database  
            db = new DBHelper();
            db.createDatabase();
            lstViewData = v.FindViewById<ListView>(Resource.Id.listView);
            
            //Load Data  
            LoadData();

            lstViewData.ItemClick += (s, e) =>
            {
                var txtId = e.View.FindViewById<TextView>(Resource.Id.txtView_Id).Text;
                var txtName = e.View.FindViewById<TextView>(Resource.Id.txtView_Name).Text;
                var txtBalance = e.View.FindViewById<TextView>(Resource.Id.txtView_Balance).Text;
                var txtDate = e.View.FindViewById<TextView>(Resource.Id.txtView_Date).Text;
                BtnshowPopup_Click(txtId, txtName, txtBalance, txtDate);
            };

            

            lstViewData.ItemLongClick += (s, e) =>
            {
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(Activity);
                alertDialog.SetTitle("Delete Person");
                alertDialog.SetMessage("Are you sure you want to delete?");

                alertDialog.SetPositiveButton("OK", delegate
                {
                    alertDialog.Dispose();

                    var txtId = e.View.FindViewById<TextView>(Resource.Id.txtView_Id).Text;
                    var txtName = e.View.FindViewById<TextView>(Resource.Id.txtView_Name).Text;
                    var txtBalance = e.View.FindViewById<TextView>(Resource.Id.txtView_Balance).Text;
                    var txtDate = e.View.FindViewById<TextView>(Resource.Id.txtView_Date).Text;

                    Person person = new Person()
                    {
                        Id = int.Parse(txtId),
                        Name = txtName,
                        Balance = Convert.ToDouble(txtBalance),
                        DateOfBirth = txtDate
                    };
                    db.removeTable(person);
                    LoadData();

                    Toast.MakeText(Activity, txtName + " Deleted", ToastLength.Long).Show();

                    
                });

                alertDialog.SetNegativeButton("Cancel", delegate
                {
                    alertDialog.Dispose();
                });

                alertDialog.Show();

                
            };




            return v;
        }

        private void LoadData()
        {
            listSource = db.selectTable();
            var adapter = new LvAdapter(Activity, listSource);
            lstViewData.Adapter = adapter;
            if(lstViewData.Count == 0)
                Toast.MakeText(Application.Context,"No Customer Records", ToastLength.Short).Show();
        }



        private void BtnshowPopup_Click(string id, string name, string balance, string date)
        {

            
            LayoutInflater layoutInflater = LayoutInflater.From(Activity);
            View view = layoutInflater.Inflate(Resource.Layout.UpdatePopup, null);
            AlertDialog.Builder alertbuilder = new AlertDialog.Builder(Activity);
            alertbuilder.SetView(view);
            alertbuilder.SetTitle("Update Person");

            var txtId = view.FindViewById<TextView>(Resource.Id.edtId);
            var txtName = view.FindViewById<EditText>(Resource.Id.edtName);
            var txtBalance = view.FindViewById<EditText>(Resource.Id.edtBalance);
            var txtDate = view.FindViewById<EditText>(Resource.Id.edtDate);
            

            txtDate.Text = DateTime.Now.ToShortDateString();
            txtDate.Click += delegate
            {
                new DatePickerFragment(delegate (DateTime time) {

                    DateTime _selectedDate = time;
                    txtDate.Text = _selectedDate.ToShortDateString();
                }).Show(FragmentManager, DatePickerFragment.TAG);
            };


            txtId.Text = id;
            txtName.Text = name;
            txtBalance.Text = balance;
            txtDate.Text = date;

            alertbuilder.SetCancelable(false)
            .SetPositiveButton("Update", delegate
            {

                Person person = new Person()
                {
                    Id = int.Parse(txtId.Text),
                    Name = txtName.Text,
                    Balance = Convert.ToDouble(txtBalance.Text),
                    DateOfBirth = txtDate.Text
                };
                db.updateTable(person);
                LoadData();
                Toast.MakeText(Activity, txtName.Text + " Updated", ToastLength.Short).Show();
            })
            .SetNegativeButton("Cancel", delegate
            {
                alertbuilder.Dispose();
            });
            AlertDialog dialog = alertbuilder.Create();
            dialog.Show();


        }

        



    }
}