using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kKargo.ORM.Entity
{
    public class Müsteri
    {
        public int MusteriID { get; set; }
        public int SevkiyatID { get; set; }
        public string MAdSoyad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string OdemeDurumu { get; set; }
        public int SubeID { get; set; }

    }
}
