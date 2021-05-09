using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Snackbar;
using System;
using System.Collections.Generic;

namespace Assignment2.Fragments
{
    [System.Obsolete]
    public class CrudFragment : Fragment
    {

        
        List<Person> listSource = new List<Person>();
        DBHelper db;
        View view;
        EditText edtDate, edtBalance, edtName;
        private DateTime _selectedDate;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.CrudFragment, container, false);



            
            db = new DBHelper();
            db.createDatabase();
           
            edtName = view.FindViewById<EditText>(Resource.Id.edtName);
            edtDate = view.FindViewById<EditText>(Resource.Id.edtDate);
            edtBalance = view.FindViewById<EditText>(Resource.Id.edtBalance);
            var btnAdd = view.FindViewById<Button>(Resource.Id.btnAdd);
            var btnReset = view.FindViewById<Button>(Resource.Id.btnReset);
            


           
            edtDate.Click += delegate
            {
                new DatePickerFragment(delegate (DateTime time) { 
                    _selectedDate = time;
                    edtDate.Text = _selectedDate.ToShortDateString(); 
                }).Show(FragmentManager, DatePickerFragment.TAG);
            };



            btnAdd.Click += delegate
            {
                Person person = new Person()
                {
                    Name = edtName.Text,
                    Balance = Convert.ToDouble(edtBalance.Text),
                    DateOfBirth = edtDate.Text
                };
                db.insertIntoTable(person);
                Toast.MakeText(Application.Context, edtName.Text + " Person Added", ToastLength.Short).Show();
                edtName.Text = "";
                edtDate.Text = "";
                edtBalance.Text = "";
                

            };

            btnReset.Click += delegate
            {
                edtName.Text = "";
                edtDate.Text = "";
                edtBalance.Text = "";

            };
            
          
            





            return view;
        }


        



    }

   
    



}