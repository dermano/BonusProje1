using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusProje1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0NNHPCV\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True;");
        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            FrmOgrenciNotlar fr = new FrmOgrenciNotlar();
            fr.numara = textBox1.Text;
            
            SqlCommand komut = new SqlCommand("SELECT OGRAD FROM TBLOGRENCI WHERE OGRID = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            
            if (dr.Read())
            {
                fr.Text = dr["OGRAD"].ToString();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("E Bu kişi yok");
            }
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen fr = new FrmOgretmen();
            fr.Show();
            this.Hide();
        }
    }
}
