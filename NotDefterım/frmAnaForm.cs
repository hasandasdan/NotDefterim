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
using DataAccessLayer;
using Entities;
using Microsoft.VisualBasic;

namespace NotDefterım
{
    public partial class frmAnaForm : Form
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }

        public int NotId { get; set; }
        public int kategoriId { get; set; }
        public int KategoriId { get; set; }
           
    public  Kullanicilar GirisYapanKullanicilar { get;  set; }

        #region Listeleme
        private void GÜncelNotSıralama()
        {
            KategoriIslemleri kategoriIslemleri = new KategoriIslemleri();

            DataTable dt = kategoriIslemleri.GüncelNotKategori(kategoriId);



            flyBaslikNot.Controls.Clear();

            foreach (DataRow dr in dt.Rows)
            {

                FlowLayoutPanel layoutPanel = new FlowLayoutPanel();
                layoutPanel.Click += LayoutPanel_Click;

                layoutPanel.BorderStyle = BorderStyle.FixedSingle;
                layoutPanel.Width = 167;
                layoutPanel.Height = 60;

                //  layoutPanel.Margin = new Padding(2, 2, 2, 2);
                var YazilanNot = new Label();
                YazilanNot.Width = 167;
                YazilanNot.Height = 40;
                var baslik = new Label();
                baslik.Text = dr["Baslik"].ToString();
                baslik.Tag = dr[0].ToString();

                layoutPanel.Tag = dr["ID"].ToString();

                //  baslik.BorderStyle = BorderStyle.Fixed3D;
                baslik.Font = new Font("Arial", 10, FontStyle.Bold);

                //   YazilanNot.Text = dr["YazilanNot"].ToString();
                string not = dr["YazilanNot"].ToString();


                if (not.Length >= 26 && not.Length < 52)
                {
                    YazilanNot.Text = not.Substring(0, 26) + Environment.NewLine + not.Substring(52 - 26);//Environment.NewLine 
                }
                else if (not.Length >= 52)
                {
                    YazilanNot.Text = not.Substring(0, 26) + Environment.NewLine + not.Substring(26, 23) + "...";

                }
                else
                {
                    YazilanNot.Text = not;
                }

                YazilanNot.Tag = dr["ID"].ToString();

                //    YazilanNot.BorderStyle = BorderStyle.Fixed3D;
                YazilanNot.Font = new Font("Arial", 8);

                layoutPanel.Controls.Add(baslik);
                layoutPanel.Controls.Add(YazilanNot);
                flyBaslikNot.Controls.Add(layoutPanel);

            }
        }

        private void NotListele()
        {
            KategoriIslemleri kategoriIslemleri = new KategoriIslemleri();

            DataTable dt = kategoriIslemleri.KategoriSec(kategoriId);



            flyBaslikNot.Controls.Clear();

            foreach (DataRow dr in dt.Rows)
            {

                FlowLayoutPanel layoutPanel = new FlowLayoutPanel();
                layoutPanel.Click += LayoutPanel_Click;

                layoutPanel.BorderStyle = BorderStyle.FixedSingle;
                layoutPanel.Width = 167;
                layoutPanel.Height = 60;

                //  layoutPanel.Margin = new Padding(2, 2, 2, 2);
                var YazilanNot = new Label();
                YazilanNot.Width = 167;
                YazilanNot.Height = 40;
                var baslik = new Label();
                baslik.Text = dr["Baslik"].ToString();
                baslik.Tag = dr[0].ToString();

                layoutPanel.Tag = dr["ID"].ToString();

                //  baslik.BorderStyle = BorderStyle.Fixed3D;
                baslik.Font = new Font("Arial", 10, FontStyle.Bold);

                //   YazilanNot.Text = dr["YazilanNot"].ToString();
                string not = dr["YazilanNot"].ToString();


                if (not.Length >= 26 && not.Length < 52)
                {
                    YazilanNot.Text = not.Substring(0, 26) + Environment.NewLine + not.Substring(52 - 26);//Environment.NewLine 
                }
                else if (not.Length >= 52)
                {
                    YazilanNot.Text = not.Substring(0, 26) + Environment.NewLine + not.Substring(26, 23) + "...";

                }
                else
                {
                    YazilanNot.Text = not;
                }

                YazilanNot.Tag = dr["ID"].ToString();

                //    YazilanNot.BorderStyle = BorderStyle.Fixed3D;
                YazilanNot.Font = new Font("Arial", 8);

                layoutPanel.Controls.Add(baslik);
                layoutPanel.Controls.Add(YazilanNot);
                flyBaslikNot.Controls.Add(layoutPanel);

            }
        }
        private void KategoriListele()
        {
            KategoriIslemleri kategoriIslemleri = new KategoriIslemleri();

            DataTable dt = kategoriIslemleri.KategoriLoad(GirisYapanKullanicilar.Id);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "KategoriAd";
            comboBox2.ValueMember = "ID";
            flypanel.Controls.Clear();
            flyBaslikNot.Controls.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                var b = new Label();
                b.Height = 20;
                b.Font = new Font("Tahoma", 8, FontStyle.Bold);
                //  b.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;

                b.ForeColor = Color.White;
                b.Text = dr["KategoriAd"].ToString();
                b.Tag = dr["ID"].ToString();
                b.Click += b_Click;

                flypanel.Controls.Add(b);

            }
        } 
        #endregion

        private void frmAnaForm_Load(object sender, EventArgs e)
        {

          
            lblKullaniciAdsoyad.Text = GirisYapanKullanicilar.Ad + " " + GirisYapanKullanicilar.Soyad;
            pnl_notEkle.Hide();
            // Kategori kategori = new Kategori();
            //List<Kategori> kategoriler= kategori.GetirKategori(GirisYapanKullanicilar.Id);
            // comboBox2.DataSource = kategoriler;   
            //foreach (DataRow dr in dt.Rows)
            //{
            //    comboBox2.Items.Add(dr["KategoriAd"].ToString());
            //}

            KategoriListele();
            KategoriIslemleri kategoriIslemleri = new KategoriIslemleri();
            List<Kategori> kategoriler = kategoriIslemleri.kategoriGetir(GirisYapanKullanicilar.Id);
           
            foreach (var item in kategoriler)
            {
                KategoriId = item.Id;
            }
        
            
            DataTable dt = kategoriIslemleri.KategoriSec(KategoriId);



            flyBaslikNot.Controls.Clear();

            foreach (DataRow dr in dt.Rows)
            {

                FlowLayoutPanel layoutPanel = new FlowLayoutPanel();
                layoutPanel.Click += LayoutPanel_Click;

                layoutPanel.BorderStyle = BorderStyle.FixedSingle;
                layoutPanel.Width = 167;
                layoutPanel.Height = 60;

                //  layoutPanel.Margin = new Padding(2, 2, 2, 2);
                var YazilanNot = new Label();
                YazilanNot.Width = 167;
                YazilanNot.Height = 40;
                var baslik = new Label();
                baslik.Text = dr["Baslik"].ToString();
                baslik.Tag = dr[0].ToString();

                layoutPanel.Tag = dr["ID"].ToString();

                //  baslik.BorderStyle = BorderStyle.Fixed3D;
                baslik.Font = new Font("Arial", 10, FontStyle.Bold);

                //   YazilanNot.Text = dr["YazilanNot"].ToString();
                string not = dr["YazilanNot"].ToString();


                if (not.Length >= 26 && not.Length < 52)
                {
                    YazilanNot.Text = not.Substring(0, 26) + Environment.NewLine + not.Substring(52 - 26);//Environment.NewLine 
                }
                else if (not.Length >= 52)
                {
                    YazilanNot.Text = not.Substring(0, 26) + Environment.NewLine + not.Substring(26, 23) + "...";

                }
                else
                {
                    YazilanNot.Text = not;
                }

                YazilanNot.Tag = dr["ID"].ToString();

                //    YazilanNot.BorderStyle = BorderStyle.Fixed3D;
                YazilanNot.Font = new Font("Arial", 8);

                layoutPanel.Controls.Add(baslik);
                layoutPanel.Controls.Add(YazilanNot);
                flyBaslikNot.Controls.Add(layoutPanel);

            }
        }

        #region LabelKategoriGosterimi

        private void b_Click(object sender, EventArgs e)
        {
            Label secilen = (Label)sender;
            kategoriId = Convert.ToInt32(secilen.Tag);

            NotListele();

        }

 
        #endregion

        #region PanaldeNotlarınGösterimi
        private void LayoutPanel_Click(object sender, EventArgs e)
        {

            pnl_notEkle.Show();
            // Label secilen = (Label)sender;
            FlowLayoutPanel sec = (FlowLayoutPanel)sender;

            NotId = Convert.ToInt32(sec.Tag);

            KategoriIslemleri kategoriIslemleri = new KategoriIslemleri();

            DataTable dt = kategoriIslemleri.KategoriGoster(NotId);

            foreach (DataRow dr in dt.Rows)
            {

                comboBox2.Text = dr["KategoriAd"].ToString();
                txtBaslıkEkle.Text = dr["Baslik"].ToString();
                txtNotEkle.Text = dr["YazilanNot"].ToString();


            }

        } 
        #endregion

        private void yeniNotToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            frm_NotEkle frmekle = new frm_NotEkle();
            frmekle.GirisYapan = GirisYapanKullanicilar;
            frmekle.ShowDialog();
           
        }
             
        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            string KategoriAdi;
            KategoriAdi = Interaction.InputBox("Kategori Adını Yazınız");

            //   listBox1.Items.Add(KategoriAdi);
            //for (int i = 0; i < listBox1.Items.Count; i++)
            //{
            Kategori kategori = new Kategori()
            {
                KullaniciID = GirisYapanKullanicilar.Id,
                KategoriAd = KategoriAdi,
                KayitTarihi = DateTime.Now,


            };
            KategoriIslemleri kk = new KategoriIslemleri();
            int sonuc = kk.KategoriEk(kategori);
            if (sonuc > 0)
            {

                MessageBox.Show("Kategori Eklendi");
                KategoriListele();

            }
            else
            {
                MessageBox.Show("Kategori Eklenemedi");
            }
        }

        private void btnKayıtEkle_Click(object sender, EventArgs e)
        {
            Notlar not = new Notlar()
            {
                ID = NotId

            };
            NotIslemleri notIslemleri = new NotIslemleri();
            int sonuc = notIslemleri.NotSil(not);
            DialogResult cevap;
            cevap = MessageBox.Show("Silmek istediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);

            if (cevap == DialogResult.Yes)
            {
                if (sonuc > 0)
                {
                    MessageBox.Show("Notunuz Silindi");
                    NotListele();
                }

                else
                {
                    MessageBox.Show("Notunuz Silinemedi");
                }
            }
        }

  

        private void btnNotGuncelle_Click(object sender, EventArgs e)
        {
            Notlar not = new Notlar()
            {
                ID = NotId,
                Baslik = txtBaslıkEkle.Text,
                YazilanNot = txtNotEkle.Text,
                KayıtTarihi = DateTime.Now,
                GüncellemeTarihi = DateTime.Now,
                KategoriID = (int)comboBox2.SelectedValue,
                KaydedenKisi = GirisYapanKullanicilar.Ad + " " + GirisYapanKullanicilar.Soyad,
                GüncelleyenKisi = GirisYapanKullanicilar.Ad + " " + GirisYapanKullanicilar.Soyad,
            };

            NotIslemleri notEkle = new NotIslemleri();
            int sonuc = notEkle.NotDuzenle(not);
            if (sonuc > 0)
            {
                MessageBox.Show("Notunuz Oluşruldu");
                GÜncelNotSıralama();

            }
            else
            {
                MessageBox.Show("Not Eklenemedi");
            }
        }

        private void btnNotEkle_Click(object sender, EventArgs e)
        {
            frm_NotEkle frmekle = new frm_NotEkle();
            frmekle.GirisYapan = GirisYapanKullanicilar;
            frmekle.ShowDialog();
        }

 
        private void btnKategoriSİl_Click(object sender, EventArgs e)
        {
             Kategori kategori = new Kategori()
            {
                Id=kategoriId

            };
            KategoriIslemleri kategoriIslem = new KategoriIslemleri();
            int sonuc = kategoriIslem.KategoriSil(kategori);
            DialogResult cevap;
            cevap = MessageBox.Show("Silmek istediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);

            if (cevap == DialogResult.Yes)
            {
                if (sonuc > 0)
                {
                    MessageBox.Show("Seçtiğiniz Kategori Silindi");
                    KategoriListele();

                }
                else
                {
                    MessageBox.Show("Seçtiğiniz Kategori Silinemedi");
                }
            }
        }


    }
}
