using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using CommonLayer;

using Entities;

namespace NotDefterım
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        KullaniciIslemleri kullaniciIslemleri = new KullaniciIslemleri();
        Kullanici k = new Kullanici();
        #region AcılırMenu

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel3.Hide();
            panel4.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel1.Hide();
            panel4.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel4.Show();
            panel1.Hide();
            panel3.Hide();
        } 
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel3.Hide();
            panel4.Hide();

        }

        private void btnGiris_Click(object sender, EventArgs e)

        {
           
          k.KullaniciAdi = txtKullaniciAdi.Text.Trim();
           k.KullaniciSifre = txtSifre.Text.Trim();
            KullaniciIslemleri kullaniciIslemleri = new KullaniciIslemleri();
            //  kullaniciIslemleri.KullaniciGiris kgiris = new KullaniciGiris();
            Kullanicilar kullanicilar = kullaniciIslemleri.KullaniciLogin(txtKullaniciAdi.Text, txtSifre.Text);
                if (kullanicilar !=null)
                {
                    //Giriş Başarılı
                    Hide();
                    frmAnaForm frmAna = new frmAnaForm();
                frmAna.GirisYapanKullanicilar = kullanicilar;
            
                    frmAna.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı","Hatalı Giriş",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }

           

        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            k.Ad = txtKAd.Text.Trim();
            k.Soyad = txtKSoyad.Text.Trim();
            k.KullaniciAdi = txtKKullaniciAdi.Text.Trim();
            k.KullaniciSifre = txtKSifre.Text.Trim();
            k.Email = txtKEmail.Text.Trim();
            OnDenetleme(k.Ad, k.Soyad, k.KullaniciAdi, k.KullaniciSifre, k.Email);
            Kullanicilar kul = new Kullanicilar()
            {
                Ad = txtKAd.Text,
                Soyad = txtKSoyad.Text,
                KullaniciAdi = txtKKullaniciAdi.Text,
                KullaniciSifre = txtKSoyad.Text,
                Eposta = txtKEmail.Text,
                AktifMi = true,
            };

            int sonuc = kullaniciIslemleri.kullaniciK(kul);
            if (sonuc > 0)
            {
                MessageBox.Show("Kaydınız Oluşruldu");
                //foreach (Control item in this.Controls)
                //{
                //    if (item is TextBox)
                //    {
                //        TextBox tbox = (TextBox)item;
                //        tbox.Clear();
                //    }
                //}
            }
            else
            {
                MessageBox.Show("Kaydınız Eklenemedi");
            }

        }

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {

            k.KullaniciAdi = txtSKullaniciAdi.Text.Trim();
            k.KullaniciSifre = txtSSifre.Text.Trim();
            k.Email = txtSEmail.Text.Trim();
            OnDenetleme(k.KullaniciAdi, k.KullaniciSifre, k.Email);



            Kullanicilar kul = new Kullanicilar()
            {
                KullaniciAdi = txtSKullaniciAdi.Text,
                KullaniciSifre = txtSSifre.Text,
                Eposta = txtSEmail.Text,
            };


            // int sonuc = ku.kullaniciK(kul);
            if (kullaniciIslemleri.kullanicisifre(kul) > 0)
            {
                MessageBox.Show("Şifreniz Güncellenmiştir");
                //foreach (Control item in this.Controls)
                //{
                //    if (item is TextBox)
                //    {
                //        TextBox tbox = (TextBox)item;
                //        tbox.Clear();
                //    }
                //}
            }
            else
            {
                MessageBox.Show("Kullanıcı Adınız veya Eposta Adresiniz Hatalı!!!");
            }

        }

        #region Ondenetleme

        private bool OnDenetleme(string a, string b)
        {
            bool result = false;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(a))
            {
                errorProvider1.SetError(txtKullaniciAdi, "Kullanıcı adı Boş geçilemez");
                result = true;
            }
            if (string.IsNullOrEmpty(b))
            {
                errorProvider1.SetError(txtSifre, "Şifre Boş geçilemez");
                result = true;
            }
            return result;
        }

        private bool OnDenetleme(string a, string b, string c)
        {

            bool result = false;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(a))
            {
                errorProvider1.SetError(txtSKullaniciAdi, "Kullanıcı adı Boş geçilemez");
                result = true;
            }
            if (string.IsNullOrEmpty(b))
            {
                errorProvider1.SetError(txtSSifre, "Şifre Boş geçilemez");
                result = true;
            }
            if (string.IsNullOrEmpty(c))
            {
                errorProvider1.SetError(txtSEmail, "E-mail adı Boş geçilemez");
                result = true;
            }
            return result;
        }

        private bool OnDenetleme(string a, string b, string c, string d, string e)
        {
            bool result = false;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(a))
            {
                errorProvider1.SetError(txtKAd, "Ad Boş geçilemez");
                result = true;
            }
            if (string.IsNullOrEmpty(b))
            {
                errorProvider1.SetError(txtKSoyad, "Soyad Boş geçilemez");
                result = true;
            }
            if (string.IsNullOrEmpty(c))
            {
                errorProvider1.SetError(txtKKullaniciAdi, "Kullanıcı adı Boş geçilemez");
                result = true;
            }
            if (string.IsNullOrEmpty(d))
            {
                errorProvider1.SetError(txtKSifre, "Şifre Boş geçilemez");
                result = true;
            }
            if (string.IsNullOrEmpty(e))
            {
                errorProvider1.SetError(txtKEmail, "E-mail adı Boş geçilemez");
                result = true;
            }

            return result;
        }








        #endregion
    }
 }

   



      
    

    

