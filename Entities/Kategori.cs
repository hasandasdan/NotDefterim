using CommonLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kategori
    {
        public int Id { get; set; }
        public string KategoriAd { get; set; }
        public  int KullaniciID { get; set; }
        public DateTime KayitTarihi { get; set; }



    }
}
