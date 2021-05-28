using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExpensesApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Handle_ItemTapped(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
            {
                return;
            }

           ((CollectionView)sender).SelectedItem = null;
            var selected = (e.CurrentSelection?.First() as ExpenseModel);
            await Navigation.PushModalAsync(new DetailPage(selected), true);
        }

        async void OnImageAddTapped(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PushModalAsync(new AddingPage(), true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        async void OnImageSettingsTapped(object sender, EventArgs args)
        {
            try
            {
                await Navigation.PushModalAsync(new SettingsPage(), true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
