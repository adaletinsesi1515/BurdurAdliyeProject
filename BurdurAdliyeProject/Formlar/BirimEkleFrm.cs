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
    }
}
