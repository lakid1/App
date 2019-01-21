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
    public partial class Profile : ContentPage
    {
        RestApi call = new RestApi();
        public Profile()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            try {
                userInfo.BindingContext = await call.GetUserInfoAsync();
            }
            catch {
                await DisplayAlert("Error", "Chyba připojení", "OK");
                await Navigation.PopModalAsync();
            }
            base.OnAppearing();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}