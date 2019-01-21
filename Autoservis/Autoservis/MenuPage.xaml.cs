﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Autoservis
{
    public partial class MenuPage : MasterDetailPage
    {
        public MenuPage()
        {
            InitializeComponent();
            // Create menu pages
            listView.ItemsSource = new List<MenuItem>
            {
                new MenuItem {Name = "DashBoard", Link = new DashBoard(), Icon="home.png"},
                new MenuItem {Name = "Historie", Link = new History(), Icon="history.png"}
            };
            Detail = new NavigationPage(new DashBoard());
            //var color = new AppColors();
            Detail.SetValue(NavigationPage.BarBackgroundColorProperty, Color.FromHex("#0277bd"));
        }

        //Navigation select
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Page = e.SelectedItem as MenuItem;
            Detail = new NavigationPage(Page.Link);
            //var color = new AppColors();
            Detail.SetValue(NavigationPage.BarBackgroundColorProperty, Color.FromHex("#0277bd"));
            
            IsPresented = false;
        }

        //Logout
        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            var app = Application.Current as App;
            app.Token = "";
            app.ExpireDate = "";
            app.MainPage = new Login();
        }

        private async void ProfileButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Profile());
        }
    }
}
