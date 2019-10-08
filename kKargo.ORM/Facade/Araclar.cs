using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kKargo.ORM.Entity;
using System.Data;
using System.Data.SqlClient;

namespace kKargo.ORM.Facade
{
    public class Araclar
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("AracListele", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }

        public static bool Ekle(Arac nesne)
        {
            SqlCommand kaydet = new SqlCommand("AracEkle", Tools.Baglanti);
            kaydet.CommandType = CommandType.StoredProcedure;
            kaydet.Parameters.AddWithValue("@AracTuru", nesne.AracTuru);
            kaydet.Parameters.AddWithValue("@AracKapasitesi", nesne.AracKapasitesi);
            kaydet.Parameters.AddWithValue("@AracSoforu", nesne.AracSoforu);

            return Tools.ExecuteNonQuery(kaydet);
        }
        public static bool Sil(Arac nesne)
        {
            SqlCommand sil = new SqlCommand("AracSil", Tools.Baglanti);
            sil.CommandType = CommandType.StoredProcedure;
            sil.Parameters.AddWithValue("@AracID", nesne.AracID);

            return Tools.ExecuteNonQuery(sil);

        }

        public static bool Yenile(Arac nesne)
        {
            SqlCommand kaydet = new SqlCommand("AracYenile", Tools.Baglanti);
            kaydet.CommandType = CommandType.StoredProcedure;
            kaydet.Parameters.AddWithValue("@AracID", nesne.AracID);
            kaydet.Parameters.AddWithValue("@AracTuru", nesne.AracTuru);
            kaydet.Parameters.AddWithValue("@AracKapasitesi", nesne.AracKapasitesi);
            kaydet.Parameters.AddWithValue("@AracSoforu", nesne.AracSoforu);
            return Tools.ExecuteNonQuery(kaydet);
        }






    }
}
