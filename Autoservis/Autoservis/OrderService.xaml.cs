using Autoservis.Class;
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
    public partial class OrderService : ContentPage
    {
        private RestApi call = new RestApi();
        private IList<Car> _cars;
        private int _id;
        private DateTime _date = DateTime.Today.AddDays(1);
        public OrderService()
        {
            InitializeComponent();
            //<a href="https://www.freepik.com/free-vector/abstract-blue-background_859016.htm">Designed by Kjpargeter</a>

            image.Source = ImageSource.FromResource("Autoservis.Images.1511.jpg");

        }
        protected override async void OnAppearing()
        {
            _cars = await call.GetCarsAsync();
            foreach (var method in _cars)
            {
                vozidloPicker.Items.Add(method.Spz + " " + method.Znacka + " " + method.Model + " " + method.Rok);
            }
            base.OnAppearing();
        }

        private void VozidloPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var car = vozidloPicker.Items[vozidloPicker.SelectedIndex];

            var carMethod = _cars.Single(cm => cm.Spz + " " + cm.Znacka + " " + cm.Model + " " + cm.Rok == car);
            // DisplayAlert("ID", carMethod.Id.ToString(), "OK");
            _id = carMethod.Id;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                return;
            }
            else
            {
                var result = await call.AddOrderAsync(_id, _date);
                if (result == true)
                {
                    await DisplayAlert("Objednávka", "Vaše objednávka byla přijata", "OK");
                    Navigation.RemovePage(this);
                }
                else
                {
                    await DisplayAlert("Objednávka", "Chyba!!!", "OK");

                }
            }

        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            _date = e.NewDate;
        }
    }
}