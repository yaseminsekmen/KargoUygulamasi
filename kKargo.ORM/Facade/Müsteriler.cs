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
    public class Müsteriler
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("MusteriListele", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }

        public static bool Ekle(Müsteri nesne)
        {
            SqlCommand kaydet = new SqlCommand("MusteriEkle", Tools.Baglanti);
            kaydet.CommandType = CommandType.StoredProcedure;
            kaydet.Parameters.AddWithValue("@SevkiyatID", nesne.SevkiyatID);
            kaydet.Parameters.AddWithValue("@MAdSoyad", nesne.MAdSoyad);
            kaydet.Parameters.AddWithValue("@Adres", nesne.Adres);
            kaydet.Parameters.AddWithValue("@Telefon", nesne.Telefon);
            kaydet.Parameters.AddWithValue("@Mail", nesne.Mail);
            kaydet.Parameters.AddWithValue("@OdemeDurumu", nesne.OdemeDurumu);
            kaydet.Parameters.AddWithValue("@SubeID", nesne.SubeID);

            return Tools.ExecuteNonQuery(kaydet);
        }
        public static bool Sil(Müsteri nesne)
        {
            SqlCommand sil = new SqlCommand("MusteriSil", Tools.Baglanti);
            sil.CommandType = CommandType.StoredProcedure;
            sil.Parameters.AddWithValue("@MusteriID", nesne.MusteriID);

            return Tools.ExecuteNonQuery(sil);

        }

        public static bool Yenile(Müsteri nesne)
        {
            SqlCommand kaydet = new SqlCommand("MusteriYenile", Tools.Baglanti);
            kaydet.CommandType = CommandType.StoredProcedure;
            kaydet.Parameters.AddWithValue("@MusteriID", nesne.MusteriID);
            kaydet.Parameters.AddWithValue("@SevkiyatID", nesne.SevkiyatID);
            kaydet.Parameters.AddWithValue("@MAdSoyad", nesne.MAdSoyad);
            kaydet.Parameters.AddWithValue("@Adres", nesne.Adres);
            kaydet.Parameters.AddWithValue("@Telefon", nesne.Telefon);
            kaydet.Parameters.AddWithValue("@Mail", nesne.Mail);
            kaydet.Parameters.AddWithValue("@OdemeDurumu", nesne.OdemeDurumu);
            kaydet.Parameters.AddWithValue("@SubeID", nesne.SubeID);
            return Tools.ExecuteNonQuery(kaydet);
        }
        public static DataTable Doldur()
        {
            SqlCommand komut = new SqlCommand();
            DataTable doldur = new DataTable();
            SqlDataAdapter goster = new SqlDataAdapter("select SubeID from Subeler", Tools.Baglanti);
            goster.Fill(doldur);
            return doldur;
        }
        public static DataTable Doldurr()
        {
            SqlCommand komut = new SqlCommand();
            DataTable doldur = new DataTable();
            SqlDataAdapter goster = new SqlDataAdapter("select SevkiyatID from Sevkiyat", Tools.Baglanti);
            goster.Fill(doldur);
            return doldur;
        }

    }
}
