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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }



        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            if (email.Text != null && password.Text != null)
            {
                activityIndicator.IsRunning = true;
                try
                {
                    var call = new RestApi();
                    if (await call.Login(email.Text, password.Text))
                    {
                        Application.Current.MainPage = new MenuPage();
                    }
                    else
                    {
                        await DisplayAlert("Error", "Nesprávné jméno nebo heslo", "OK");
                    }
                }
                catch
                {
                   await DisplayAlert("Error", "Připojení selhalo", "OK");
                }
                activityIndicator.IsRunning = false;

            }
            else
            {
                email.Focus();
            }

        }
    }
}