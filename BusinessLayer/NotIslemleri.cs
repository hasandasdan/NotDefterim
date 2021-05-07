using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;
using DataAccessLayer;
using Entities;

namespace BusinessLayer
{
   public class NotIslemleri
    {
        SqlDataProvider provider =
           new SqlDataProvider(AppConfigHelper.GetConnectionString("NotDefterimDbConn"));
        public int NotEk(Notlar notlar)
        {
            string sorgu = "INSERT INTO Notlar(Baslik,YazilanNot,KayıtTarihi,KategoriID,KaydedenKisi,KullanıcıID) VALUES (@Baslik, @YazilanNot, @KayıtTarihi, @KategoriID,@KaydedenKisi,@KullanıcıID)";

            provider.Command.CommandText = sorgu;
            provider.Command.Parameters.AddWithValue("@Baslik", notlar.Baslik);
            provider.Command.Parameters.AddWithValue("@YazilanNot", notlar.YazilanNot);
            provider.Command.Parameters.AddWithValue("@KayıtTarihi", notlar.KayıtTarihi);
          provider.Command.Parameters.AddWithValue("@KaydedenKisi", notlar.KaydedenKisi);
            

           provider.Command.Parameters.AddWithValue("@KullanıcıID", notlar.KullanıcıID);
            provider.Command.Parameters.AddWithValue("@KategoriID", notlar.KategoriID);
            return provider.RunQuery(sorgu);


        }
        public int NotDuzenle(Notlar notlar)
        {
           
            string sorgu = "UPDATE Notlar SET Baslik=@Baslik,YazilanNot=@YazilanNot,KayıtTarihi=@KayıtTarihi,GüncellemeTarihi=@GüncellemeTarihi,KaydedenKisi=@KaydedenKisi,GüncelleyenKisi=@GüncelleyenKisi WHERE ID=@ID ";
            provider.Command.CommandText = sorgu;
         
            provider.Command.Parameters.AddWithValue("@Baslik", notlar.Baslik);
            provider.Command.Parameters.AddWithValue("@YazilanNot", notlar.YazilanNot);
            provider.Command.Parameters.AddWithValue("@KayıtTarihi", notlar.KayıtTarihi);
            provider.Command.Parameters.AddWithValue("@KaydedenKisi", notlar.KaydedenKisi);
            provider.Command.Parameters.AddWithValue("@GüncellemeTarihi", notlar.GüncellemeTarihi);
            provider.Command.Parameters.AddWithValue("@GüncelleyenKisi", notlar.GüncelleyenKisi);
          
            provider.Command.Parameters.AddWithValue("@ID", notlar.ID);
            return provider.RunQuery(sorgu);
        }
        public int NotSil(Notlar notlar)
        {
            string sorgu = "DELETE FROM Notlar where ID=@ID";
            provider.Command.CommandText = sorgu;
            provider.Command.Parameters.AddWithValue("@ID", notlar.ID);
            return provider.RunQuery(sorgu);
        }
       

    }
}
