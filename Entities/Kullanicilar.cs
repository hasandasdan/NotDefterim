using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kullanicilar
    {
    //    ID
    //    KullaniciAdi
    //    KullaniciSifre
    //    Ad
    //    Soyad
    //    Eposta
    //    KayıtTarihi
    //    KaydedenKisi
    //    GüncellemeTarihi
    //    GüncelleyenKisi
    //    AktifMi
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public DateTime KayıtTarihi { get; set; }
        public string KaydedenKisi { get; set; }
        public DateTime GüncellemeTarihi { get; set; }
        public string GüncelleyenKisi { get; set; }
        public bool AktifMi { get; set; }
    }

}
