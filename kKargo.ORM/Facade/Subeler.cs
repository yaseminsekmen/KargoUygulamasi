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
   public class Subeler
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("SubeListele", Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }

        public static bool Ekle(Sube nesne)
        {
            SqlCommand kaydet = new SqlCommand("SubeEkle", Tools.Baglanti);
            kaydet.CommandType = CommandType.StoredProcedure;
            kaydet.Parameters.AddWithValue("@SubeAdi", nesne.SubeAdi);
            kaydet.Parameters.AddWithValue("@SubeIl", nesne.SubeIl);
            kaydet.Parameters.AddWithValue("@SubeIlce", nesne.SubeIlce);
            kaydet.Parameters.AddWithValue("@TeslimDurumu", nesne.TeslimDurumu);

            return Tools.ExecuteNonQuery(kaydet);
        }
        public static bool Sil(Sube nesne)
        {
            SqlCommand sil = new SqlCommand("SubeSil", Tools.Baglanti);
            sil.CommandType = CommandType.StoredProcedure;
            sil.Parameters.AddWithValue("@SubeID", nesne.SubeID);

            return Tools.ExecuteNonQuery(sil);

        }

        public static bool Yenile(Sube nesne)
        {
            SqlCommand kaydet = new SqlCommand("SubeYenile", Tools.Baglanti);
            kaydet.CommandType = CommandType.StoredProcedure;
            kaydet.Parameters.AddWithValue("@SubeID", nesne.SubeID);
            kaydet.Parameters.AddWithValue("@SubeAdi", nesne.SubeAdi);
            kaydet.Parameters.AddWithValue("@SubeIl", nesne.SubeIl);
            kaydet.Parameters.AddWithValue("@SubeIlce", nesne.SubeIlce);
            kaydet.Parameters.AddWithValue("@TeslimDurumu", nesne.TeslimDurumu);
            return Tools.ExecuteNonQuery(kaydet);
        }

    }
}
