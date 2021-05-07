using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Notlar
    {
        //ID
        //Baslik
        //YazilanNot
        //KayıtTarihi
        //KaydedenKisi
        //GüncellemeTarihi
        //GüncelleyenKisi
        //KullanıcıID
        //KategoriID
       public  int ID { get; set; }
        public string Baslik { get; set; }
        public string YazilanNot { get; set; }
        public DateTime KayıtTarihi { get; set; }
        public string KaydedenKisi { get; set; }
        public DateTime GüncellemeTarihi { get; set; }
        public string GüncelleyenKisi { get; set; }
        public int KullanıcıID { get; set; }
       public int KategoriID { get; set; }

    }
}
