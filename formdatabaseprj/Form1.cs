using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer;
namespace formdatabaseprj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-HT6NQQRD;Initial Catalog=DisKlinikDb;Integrated Security=True;Trust Server Certificate=True");
            conn.Open();
            string username = TxtKullaniciAdi.Text;
            string password = TxtSifre.Text;
            SqlCommand cmd = new SqlCommand("select Username,Password from Login where Username='" + TxtKullaniciAdi.Text + "'and Password='" + TxtSifre.Text + "'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
               Anasayfa anasayfa  = new Anasayfa();
                anasayfa.Show();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir Kullanıcı Adı ve Şifre giriniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);//belirlenen  kullanıcı adı:admin şifre:1234
            }
            conn.Close();
        }
    }
    }
