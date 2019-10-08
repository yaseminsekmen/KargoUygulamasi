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
    public class Sevkiyatlar
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("SevkiyatListele", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }

        public static bool Ekle(Sevkiyat nesne)
        {
            SqlCommand kaydet = new SqlCommand("SevkiyatEkle", Tools.Baglanti);
            kaydet.CommandType = CommandType.StoredProcedure;
            kaydet.Parameters.AddWithValue("@Sadi", nesne.SAdi);
            kaydet.Parameters.AddWithValue("@SAlinanNokta", nesne.SAlinanNokta);
            kaydet.Parameters.AddWithValue("@SUlasilacakNokta", nesne.SUlasilacakNokta);
            kaydet.Parameters.AddWithValue("@Mesafe", nesne.Mesafe);
            kaydet.Parameters.AddWithValue("@MesafeTutari", nesne.MesafeTutari);
            kaydet.Parameters.AddWithValue("@AracID", nesne.AracID);

            return Tools.ExecuteNonQuery(kaydet);
        }
        public static bool Sil(Sevkiyat nesne)
        {
            SqlCommand sil = new SqlCommand("SevkiyatSil", Tools.Baglanti);
            sil.CommandType = CommandType.StoredProcedure;
            sil.Parameters.AddWithValue("@SevkiyatID", nesne.SevkiyatID);

            return Tools.ExecuteNonQuery(sil);

        }

        public static bool Yenile(Sevkiyat nesne)
        {
            SqlCommand kaydet = new SqlCommand("SevkiyatYenile", Tools.Baglanti);
            kaydet.CommandType = CommandType.StoredProcedure;
            kaydet.Parameters.AddWithValue("@SevkiyatID", nesne.SevkiyatID);
            kaydet.Parameters.AddWithValue("@SAdi", nesne.SAdi);
            kaydet.Parameters.AddWithValue("@SAlinanNokta", nesne.SAlinanNokta);
            kaydet.Parameters.AddWithValue("@SUlasilacakNokta", nesne.SUlasilacakNokta);
            kaydet.Parameters.AddWithValue("@Mesafe", nesne.Mesafe);
            kaydet.Parameters.AddWithValue("@MesafeTutari", nesne.MesafeTutari);
            kaydet.Parameters.AddWithValue("@AracID", nesne.AracID);
            return Tools.ExecuteNonQuery(kaydet);
        }

        public static DataTable Doldur()
        {
            SqlCommand komut = new SqlCommand();
            DataTable doldur = new DataTable();
            SqlDataAdapter goster = new SqlDataAdapter("select AracID from Araclar", Tools.Baglanti);
            goster.Fill(doldur);
            return doldur;
        }

    }
}
