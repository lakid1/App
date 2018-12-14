using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Autoservis
{
    public partial class App : Application
    {


        public App()
        {
            InitializeComponent();

            MainPage = new InitPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public string Token
        {
            get
            {
                if (Properties.ContainsKey("token"))
                    return Properties["token"].ToString();

                return "";
            }
            set
            {
                Properties["token"] = value;
            }
        }
        public string ExpireDate
        {
            get
            {
                if (Properties.ContainsKey("date"))
                    return Properties["date"].ToString();

                return "";
            }
            set
            {
                Properties["date"] = value;
            }
        }
    }
}
