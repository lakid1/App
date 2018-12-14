using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Autoservis
{
    class RestApi
    {
        HttpClient client = new HttpClient();

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
                    var app = Application.Current as App;
                    app.Token = response.token;
                    app.ExpireDate = response.date;
                }
                return true;
            }
            return false;
        }
    }
}
