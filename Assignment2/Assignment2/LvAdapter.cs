using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace Assignment2
{
   
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtBalance { get; set; }
        public TextView txtDate { get; set; }
    }
    public class LvAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Person> listPerson;
        public LvAdapter(Activity activity, List<Person> listPerson)
        {
            this.activity = activity;
            this.listPerson = listPerson;
        }
        public override int Count
        {
            get { return listPerson.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return listPerson[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_item, parent, false);
            var txtId = view.FindViewById<TextView>(Resource.Id.txtView_Id);
            var txtName = view.FindViewById<TextView>(Resource.Id.txtView_Name);
            var txtBalance = view.FindViewById<TextView>(Resource.Id.txtView_Balance);
            var txtDate = view.FindViewById<TextView>(Resource.Id.txtView_Date);
            txtId.Text = listPerson[position].Id.ToString();
            txtName.Text = listPerson[position].Name;
            txtBalance.Text = listPerson[position].Balance.ToString();
            txtDate.Text = listPerson[position].DateOfBirth.ToString();
            return view;
        }
    }


}