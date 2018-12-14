using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autoservis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestDemo : ContentPage
    {
        
        public RestDemo()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            GetPosts();           
        }

        private async void GetPosts()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://192.168.1.107:80/RestApi/api/post/read.php");
            var products = JsonConvert.DeserializeObject<List<User>>(response);

            listView.ItemsSource = products;
        }
        private async void GetSinglePosts()
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync("http://192.168.1.107:80/RestApi/api/post/read_single.php?id=2");
            
            var products = JsonConvert.DeserializeObject<List<User>>(response);

            listView.ItemsSource = products;
            
        }

        private async void Create()
        {
            HttpClient client = new HttpClient();
            var post = new User { email = "admin", password = "RyosukeFC", token = "" };
            var content = JsonConvert.SerializeObject(post);
            HttpResponseMessage responseMessage = await client.PostAsync("http://192.168.1.107:80/Api/Api/api/user/login.php", new StringContent(content, Encoding.UTF8, "aplication/json"));
            HttpContent response = responseMessage.Content;
            string resutl = await response.ReadAsStringAsync();
            var resutl2 = JsonConvert.DeserializeObject<User>(resutl);
            //await DisplayAlert("Response", resutl2.message + " " + resutl2.token , "OK");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            GetSinglePosts();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Create();
        }
    }
}