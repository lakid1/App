using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autoservis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryDetail : ContentPage
    {
        private OrderHistory Order;
        public HistoryDetail(OrderHistory orderHistory)
        {
            if (orderHistory == null)
                throw new ArgumentNullException();
            this.Order = orderHistory;
            BindingContext = orderHistory;
            InitializeComponent();
            Title = Order.Datum.ToString("dd/MM/yyyy") + " " + Order.Nazev.ToString();
        }
        protected override async void OnAppearing()
        {
            var call = new RestApi();
            detailListView.ItemsSource = await call.GetOrderDetailsAsync(Order.Id); 

            base.OnAppearing();
        }
    }
}