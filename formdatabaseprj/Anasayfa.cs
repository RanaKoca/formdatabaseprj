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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void Anasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Kapatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Btn_Hasta_Menu_Click(object sender, EventArgs e)
        {
            Hasta hasta = new Hasta();
            hasta.Show();
        }
    }
}
