using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace Muhasebe
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=muhasebe.accdb");

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;


        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap = new DialogResult();
            cevap = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string gsor = comboBox1.Text;
            string cevap = textBox1.Text;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=muhasebe.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM secruity where gsor='" + comboBox1.Text + "' AND cevap='" + textBox1.Text + "'";
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Güvenlik Sorusu Veya Cevap Yanlış");
            }
            con.Close();
        }
    }
}
