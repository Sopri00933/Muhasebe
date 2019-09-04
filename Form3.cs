using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Muhasebe
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=muhasebe.accdb"); 
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand sorgu_listele = new OleDbCommand("select banka_hesabi,dis,dolar,euro,vergi_borcu,tarih from hesaplar", baglanti);
            OleDbDataReader veriler = sorgu_listele.ExecuteReader();

            DataTable tablo1 = new DataTable();
            tablo1.Load(veriler);

            dataGridView1.DataSource = tablo1;
            sorgu_listele.Dispose();
            baglanti.Close();

            CancelButton = button1;
        }
    }
}
