using BusinessLayer;
using CommonLayer;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotDefterım
{
    public partial class frm_NotEkle : Form
    {
        public frm_NotEkle()
        {
            InitializeComponent();
        }

        public Kullanicilar GirisYapan { get; internal set; }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Notlar notlar = new Notlar()
            {
                Baslik = txtBaslikEkle.Text,
                YazilanNot = txtNotEkle.Text,
                KayıtTarihi = DateTime.Now,
              
                KategoriID = (int)comboBox2.SelectedValue,
                KaydedenKisi = GirisYapan.Ad + " " + GirisYapan.Soyad,
             
                KullanıcıID = GirisYapan.Id
            };
            NotIslemleri n = new NotIslemleri();
        int sonuc = n.NotEk(notlar);
            if (sonuc >0)
            {
                MessageBox.Show("Notunuz Eklendi");
            }
            else
            {
                MessageBox.Show("Not Eklenemedi");
            }

        }

        private void frm_NotEkle_Load(object sender, EventArgs e)
        {
            KategoriIslemleri kategoriIslemleri = new KategoriIslemleri();

            DataTable dt = kategoriIslemleri.KategoriLoad(GirisYapan.Id);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "KategoriAd";
            comboBox2.ValueMember = "ID";
        }
    }
}
