using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BurdurAdliyeProject.Entity;
using DevExpress.XtraEditors;
using DevExpress.XtraExport.Helpers;

namespace BurdurAdliyeProject.Formlar
{
    public partial class Birimler : Form
    {
        private BurdurAdliyeEntities db = new BurdurAdliyeEntities();
        public Birimler()
        {
            InitializeComponent();
        }

        void Listele()
        {
            var listele = (from x in db.Birimler
                select new
                {
                    x.Id,
                    x.BirimAd
                }).ToList();
            gridControl1.DataSource = listele;
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            Entity.Birimler t = new Entity.Birimler();
            t.BirimAd = txtBirimAdi.Text;
            db.Birimler.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Kayıt İşlemi Gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            txtBirimAdi.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
            txtBirimAdi.Text = gridView1.GetFocusedRowCellValue("BirimAd").ToString();
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var deger = db.Birimler.Find(x);
            db.Birimler.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Kayıt Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtBirimAdi.Text = "";
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var deger = db.Birimler.Find(x);
            deger.BirimAd = txtBirimAdi.Text;            
            db.SaveChanges();
            XtraMessageBox.Show("Kayıt Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
