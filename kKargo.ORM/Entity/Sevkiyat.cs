using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kKargo.ORM.Entity
{
   public class Sevkiyat
    {
        public int SevkiyatID { get; set; }      
        public string SAdi { get; set; }
        public string SAlinanNokta { get; set; }
        public string SUlasilacakNokta { get; set; }
        public int Mesafe { get; set; }
        public decimal MesafeTutari { get; set; }
        public int AracID { get; set; }
    }
}
