using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Autoservis
{
    class CarSelect
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Service : ContentPage
    {
        public Service()
        {
            InitializeComponent();
            foreach(var method in GetCarSelects())
            {
                picker.Items.Add(method.Name);
            }
        }


        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime dateNow = DateTime.Now;
            DateTime datePicked = e.NewDate;
            if (datePicked < dateNow)
            {
                DisplayAlert("Nesprávný formát data", string.Format("Datum je v Minulosti {0}", datePicked.ToString("dd MM yyyy")), "OK");

            }
        }

        private IList<CarSelect> GetCarSelects()
        {
            return new List<CarSelect>
            {
                new CarSelect { Id = 1, Name = "Subaru"},
                new CarSelect{ Id = 2, Name = "Toyota"}
            };
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = picker.Items[picker.SelectedIndex];
            var cars = GetCarSelects().Single(cm => cm.Name == name);
            DisplayAlert("Auto", name, "OK");
        }
    }
}