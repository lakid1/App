using System;
using System.Collections.Generic;
using System.Text;

namespace Autoservis
{
   public class OrderHistory
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Stav { get; set; }
        public string Nazev { get; set; }
    }
}
