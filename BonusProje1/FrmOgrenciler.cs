using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusProje1
{
    public partial class FrmOgrenciler : Form
    {
        public FrmOgrenciler()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0NNHPCV\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True;");

        private void FrmOgrenciler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLKULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KULUPAD";
            comboBox1.ValueMember = "KULUPID";
            comboBox1.DataSource = dt;
            baglanti.Close();
               
        }
        string c = "";
        private void BtnEkle_Click(object sender, EventArgs e)
        {

            ds.OgrenciEkle(TxtAd.Text, TxtSoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci ekleme yapıldı.");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtID.Text));
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrGuncelle(TxtAd.Text, TxtSoyad.Text,byte.Parse(comboBox1.SelectedValue.ToString()), c, int.Parse(TxtID.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "KIZ";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void TxtAra_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource =  ds.OgrenciGetir(TxtAra.Text);
        }
    }
}
