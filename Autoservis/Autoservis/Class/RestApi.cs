using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Autoservis
{
    class RestApi
    {
        HttpClient client = new HttpClient();
        App app = Application.Current as App;


        public async Task<bool> Login(string email, string password)
        {
            var user = new User { email = email, password = password };
            var content = JsonConvert.SerializeObject(user);
            var responseMessage = await client.PostAsync("http://192.168.1.107:80/Api/Api/api/user/login.php", new StringContent(content, Encoding.UTF8, "aplication/json"));
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<User>(await responseMessage.Content.ReadAsStringAsync());
                if (response.token != "")
                {
                    //var app = Application.Current as App;
                    app.Token = response.token;
                    app.ExpireDate = response.date;
                }
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<OrderHistory>> GetOrderHistoriesAsync(string searchText = null)
        {

            var user = new User { token = app.Token };
            var content = JsonConvert.SerializeObject(user);
            var responseMessage = await client.PostAsync("http://192.168.1.107/Api/Api/api/order/readHistory.php", new StringContent(content, Encoding.UTF8, "aplication/json"));
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<IEnumerable<OrderHistory>>(await responseMessage.Content.ReadAsStringAsync());
                if (String.IsNullOrWhiteSpace(searchText))
                    return response;

                return response.Where(c => (c.Datum.ToShortDateString().Contains(searchText)) || 
                (c.Auto.ToLower().Contains(searchText.ToLower())) || (c.Cena.ToString().Contains(searchText)));

            }
            return null;
        }
        public async Task<List<OrderHistoryDetail>> GetOrderDetailsAsync(int id)
        {

            var user = new User { token = app.Token, id = id };
            var content = JsonConvert.SerializeObject(user);
            var responseMessage = await client.PostAsync("http://192.168.1.107/Api/Api/api/order/readDetail.php", new StringContent(content, Encoding.UTF8, "aplication/json"));
            if (responseMessage.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeObject<List<OrderHistoryDetail>>(await responseMessage.Content.ReadAsStringAsync());
                return response;
            }
            return null;
        }
    }
}
