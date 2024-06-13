using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formdatabaseprj
{
    public partial class Hasta : Form
    {
        private int guncellemeid;
        private int silid;
        public Hasta()
        {
            InitializeComponent();
        }

        private void Hasta_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Kapatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Btn_Ekle_Click(object sender, EventArgs e)
        {
            int etkilenensatir = 0;
            using (var db = new HastaContext())
            {
                var hastalar = new Hastalar()
                {
                    AdSoyad = Txt_AdSoyad_Hasta.Text,
                    Telefon = Mtxt_Telefon.Text,
                    DogumTarihi = Date_Dogumgunu.Value,
                    Cinsiyet = Cmb_Cinsiyet.Text,
                    Alerji = Txt_Alerji.Text,
                    Adres = Txt_Adres.Text,
                    RandevuTarihi = Date_Randevu.Value,
                    Saat = Cmb_Saat.Text,
                    Tedavi = Txt_Tedavi.Text,
                };
                db.Hastalar.Add(hastalar);
                etkilenensatir = db.SaveChanges();
            }
            if (etkilenensatir > 0)
            {
                MessageBox.Show("Kayıt başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Kayıt eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           // VerileriYukle();

        }

        private void Btn_Guncelle_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Güncellemek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                using (var db = new HastaContext())
                {
                    var currentHasta = db.Hastalar.Find(guncellemeid);
                    currentHasta.AdSoyad = Txt_AdSoyad_Hasta.Text ?? string.Empty;
                    currentHasta.Telefon = Mtxt_Telefon.Text ?? string.Empty;
                    currentHasta.DogumTarihi = Date_Dogumgunu.Value;
                    currentHasta.Cinsiyet = Cmb_Cinsiyet.Text ?? string.Empty;
                    currentHasta.Alerji = Txt_Alerji.Text ?? string.Empty;
                    currentHasta.Adres = Txt_Adres.Text ?? string.Empty;
                    currentHasta.RandevuTarihi = Date_Randevu.Value;
                    currentHasta.Saat = Cmb_Saat.Text ?? string.Empty;
                    currentHasta.Tedavi = Txt_Tedavi.Text ?? string.Empty;


                    db.Hastalar.Update(currentHasta);
                    db.SaveChanges();

                }
               // VerileriYukle();
            }
        }

        private void Btn_Sil_Click(object sender, EventArgs e)
        {
            /* DialogResult cevap = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (cevap == DialogResult.Yes)
             {

                 using (var db = new HastaContext())
                 {

                     {
                         var hastalar = db.Hastalar.Find(silid);
                         db.Hastalar.Remove(hastalar);
                         db.SaveChanges();
                     }
                 }
                 //this.Close();
             }*/
            DialogResult cevap = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                try
                {
                    using (var db = new HastaContext())
                    {
                        var hastalar = db.Hastalar.Find(silid);
                        if (hastalar != null)
                        {
                            db.Hastalar.Remove(hastalar);
                            db.SaveChanges();
                            MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Silinecek kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kayıt silinirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                  //VerileriYukle();
            }

        }

        private void Btn_Ara_Click(object sender, EventArgs e)
        {
            /*using (var db = new HastaContext())
            {
                var hastalar = new List<Hastalar>();

                if (Txt_AdSoyad_Hasta.Text != "" && Txt_AdSoyad_Hasta.Text == "AdSoyad")
                {
                    var currentHasta = db.Hastalar.Find(Txt_AdSoyad_Hasta.Text);
                    hastalar.Add(currentHasta);
                }
                else
                {
                    MessageBox.Show("Lütfen aratmak istediğiniz ismi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                dataGridView_Hasta.DataSource = hastalar;
            }*/
            using (var db = new HastaContext())
             {
                 var currentHasta = db.Hastalar.Find(int.Parse(textBox5.Text));
                 guncellemeid = currentHasta.Id;
                 Txt_AdSoyad_Hasta.Text = currentHasta.AdSoyad;
                 Mtxt_Telefon.Text = currentHasta.Telefon;
                 Date_Dogumgunu.Value = currentHasta.DogumTarihi;
                 Cmb_Cinsiyet.Text = currentHasta.Cinsiyet;
                 Txt_Alerji.Text = currentHasta.Alerji;
                 Txt_Adres.Text = currentHasta.Adres;
                 Date_Randevu.Value = currentHasta.RandevuTarihi;
                 Txt_Tedavi.Text = currentHasta.Tedavi;
                 
             }
           // VerileriYukle();
        }

        private void Hasta_Load(object sender, EventArgs e)
        {
           
        }
        /*private void VerileriYukle()
        {
            try
            {
                using (var db = new HastaContext())
                {
                    dataGridView_Hasta.DataSource = db.Hastalar.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/
    }

}
