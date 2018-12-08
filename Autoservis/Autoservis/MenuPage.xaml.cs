using System;
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
            
            listView.ItemsSource = new List<MenuItem>
            {
                new MenuItem {Name = "DashBoard", Link = new DashBoard(), Icon="home.png"},
                new MenuItem {Name = "Servis", Link = new Service(), Icon="service.png"},
                new MenuItem {Name = "Historie", Link = new History(), Icon="history.png"}
            };
            Detail = new NavigationPage(new DashBoard());
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Page = e.SelectedItem as MenuItem;
            Detail = new NavigationPage(Page.Link);
            IsPresented = false;
        }
    }
}
