using CommonLayer;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class KategoriIslemleri
    {
        public int KategoriSil(Kategori kategori)
        {

            SqlDataProvider provider =
                new SqlDataProvider(AppConfigHelper.GetConnectionString("NotDefterimDbConn"));
            string sorgu = "DELETE FROM Kategori where Id=@ID";
            provider.Command.CommandText = sorgu;
            provider.Command.Parameters.AddWithValue("@ID", kategori.Id);
            return provider.RunQuery(sorgu);
        }
        public int KategoriEk(Kategori kategori)
        {
            SqlDataProvider provider =
                new SqlDataProvider(AppConfigHelper.GetConnectionString("NotDefterimDbConn"));
            string sorgu = "INSERT INTO Kategori(KategoriAd,KullaniciID,KayitTarihi) VALUES (@KategoriAd,@KullaniciID@KayitTarihi)";
            provider.Command.CommandText = sorgu;
            provider.Command.Parameters.AddWithValue("@KategoriAd", kategori.KategoriAd);
            provider.Command.Parameters.AddWithValue("@KullaniciID", kategori.KullaniciID);
            provider.Command.Parameters.AddWithValue("@KayitTarihi", kategori.KayitTarihi);
            return provider.RunQuery(sorgu);


        }
        public DataTable KategoriSec(int kategoriId)
        {
            SqlDataProvider provider =
            new SqlDataProvider(AppConfigHelper.GetConnectionString("NotDefterimDbConn"));
            string sorgu = "SELECT * FROM Notlar  where KategoriID=" + kategoriId + "ORDER BY GüncellemeTarihi DESC";
             DataTable dt = provider.GetDataTable(sorgu);
            return dt;
 
        }
        public DataTable GüncelNotKategori(int kategoriId)
        {
            SqlDataProvider provider =
            new SqlDataProvider(AppConfigHelper.GetConnectionString("NotDefterimDbConn"));
            string sorgu = "SELECT * FROM Notlar  where KategoriID="+kategoriId+"ORDER BY GüncellemeTarihi DESC";
                
            DataTable dt = provider.GetDataTable(sorgu);
            return dt;

        }


        public DataTable KategoriGoster(int NotId)
        {
            SqlDataProvider provider =
            new SqlDataProvider(AppConfigHelper.GetConnectionString("NotDefterimDbConn"));
          string sorgu = "SELECT * FROM Kategori INNER  JOIN Notlar ON Kategori.ID = Notlar.KategoriID   where Notlar.ID=" + NotId;
            DataTable dt = provider.GetDataTable(sorgu);

            return dt;

        }
        public DataTable KategoriLoad(int GirisYapanId)
        {
            SqlDataProvider provider =
            new SqlDataProvider(AppConfigHelper.GetConnectionString("NotDefterimDbConn"));
            string sorgu = "SELECT * FROM Kategori where KullaniciId=" + GirisYapanId +"ORDER BY KayitTarihi DESC";
           
            DataTable dt = provider.GetDataTable(sorgu);

            return dt;

        }

        public List<Kategori> kategoriGetir(int ıd)
        {
            List<Kategori> kategoriler = new List<Kategori>();
            SqlDataProvider provider =
           new SqlDataProvider(AppConfigHelper.GetConnectionString("NotDefterimDbConn"));
            string sorgu =" SELECT * FROM Kategori WHERE KullaniciID="+ıd;
            provider.Command.Parameters.Clear();
            provider.Command.Parameters.AddWithValue("@KullaniciID", ıd);

            DataTable dt = provider.GetDataTable(sorgu);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Kategori kategori = new Kategori()
                    {
                        Id = (int)dr["ID"],
                        KategoriAd=dr["KategoriAd"].ToString(),
                        KullaniciID=(int)dr["KullaniciID"],
                        KayitTarihi=(DateTime)dr["KayitTarihi"]


                    };
                    kategoriler.Add(kategori);
                }

            }
            return kategoriler;
        }
    }
}
