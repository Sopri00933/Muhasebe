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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=muhasebe.accdb");

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
                string user = textBox1.Text;
                string pass = textBox2.Text;
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=muhasebe.accdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM welcome where user='" + textBox1.Text + "' AND pass='" + textBox2.Text + "'";
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
                
                else
                {
                   MessageBox.Show("kullanıcı Adı Veya Şifre Yanlış");
                }
                con.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult cevap = new DialogResult();
            cevap = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.TextLength == 8)
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                errorProvider1.SetError(textBox1, "Kullanıcı Adını Boş Bırakmayınız");

            else
                errorProvider1.SetError(textBox1, "");
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Trim() == "")
                errorProvider1.SetError(textBox2, "Şifreyi Boş Bırakmayınız");

            else
                errorProvider1.SetError(textBox2, "");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = button1;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.TextLength == 18)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            this.Hide();
        }
    }
}
