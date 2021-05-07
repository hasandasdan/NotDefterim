using CommonLayer;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class KullaniciIslemleri
    {
  

        #region KullaniciLogin
        public Kullanicilar KullaniciLogin(string kullaniciAdi, string sifre)
        {
            // appconfighelper class nın içerisindeki GetConnectioniString metodun içerisinde bu isimli olanı ver 
            SqlDataProvider provider = new SqlDataProvider(AppConfigHelper.GetConnectionString("NotDefterimDbConn"));
            //veri tabanı
            string sorgu = "SELECT * FROM Kullanici AS P WHERE P.KullaniciAdi = @KullaniciAdi AND P.KullaniciSifre = @Sifre AND p.AktifMi=1";
            provider.Command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
            provider.Command.Parameters.AddWithValue("@Sifre", sifre);
            DataTable sonuc = provider.GetDataTable(sorgu);
            Kullanicilar kullan = null; ;
            if (sonuc.Rows.Count > 0)
            {
                DataRow dr = sonuc.Rows[0];

                kullan = new Kullanicilar();

                kullan.Id = (int)dr["Id"];
                kullan.KullaniciAdi = dr["KullaniciAdi"].ToString();
                kullan.KullaniciSifre = dr["KullaniciSifre"].ToString();
                kullan.Ad = dr["Ad"].ToString();
                kullan.Soyad = dr["Soyad"].ToString();
                kullan.KayıtTarihi = DateTime.Now;
                kullan.KaydedenKisi = dr["KaydedenKisi"].ToString();
                kullan.GüncellemeTarihi = DateTime.Now;
                kullan.GüncelleyenKisi = dr["GüncelleyenKisi"].ToString();
                kullan.AktifMi = (bool)dr["AktifMi"];


            }
            return kullan;
        }
        #endregion

        #region KullaniciKayit
        public int kullaniciK(Kullanicilar KKayit)
        {
            SqlDataProvider provider =
                new SqlDataProvider(AppConfigHelper.GetConnectionString("NotDefterimDbConn"));
            string sorgu = "INSERT INTO Kullanici(Ad,Soyad,KullaniciAdi,KullaniciSifre,Eposta,AktifMi) VALUES (@Ad, @Soyad, @KullaniciAdi, @KullaniciSifre,@Eposta,@AktifMi)";
            provider.Command.CommandText = sorgu;
            provider.Command.Parameters.AddWithValue("@Ad", KKayit.Ad);
            provider.Command.Parameters.AddWithValue("@Soyad", KKayit.Soyad);
            provider.Command.Parameters.AddWithValue("@KullaniciAdi", KKayit.KullaniciAdi);
            provider.Command.Parameters.AddWithValue("@KullaniciSifre", KKayit.KullaniciSifre);
            provider.Command.Parameters.AddWithValue("@Eposta", KKayit.Eposta);
            provider.Command.Parameters.AddWithValue("@AktifMi", KKayit.AktifMi);
            return provider.RunQuery(sorgu);
        }
        #endregion

        #region KullaniciSifre
        public int kullanicisifre(Kullanicilar kullanicilar)
        {
            SqlDataProvider provider = new SqlDataProvider(AppConfigHelper.GetConnectionString("NotDefterimDbConn"));

            // string sorgu = "select * from kullanici  where p.kullaniciadi =" + kullaniciadi;
            // SqlDataReader dr = provider.ExecuteRead(sorgu);
            // if (dr.Read() == true)
            //{
            //     if (email==dr["Eposta"].ToString())
            //     {

            //     }
            // }

            string sorgu = "UPDATE Kullanici SET KullaniciAdi=@KullaniciAdi,KullaniciSifre=@KullaniciSifre WHERE Eposta=@Eposta";
            //provider.Command.CommandText = sorgu;
            provider.Command.Parameters.Clear();
            provider.Command.Parameters.AddWithValue("@KullaniciAdi", kullanicilar.KullaniciAdi);
            provider.Command.Parameters.AddWithValue("@KullaniciSifre", kullanicilar.KullaniciSifre);
            provider.Command.Parameters.AddWithValue("@Eposta", kullanicilar.Eposta);
            return provider.RunQuery(sorgu);




        } 
        #endregion
    }
}
