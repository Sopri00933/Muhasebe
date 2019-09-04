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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=muhasebe.accdb");
       
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sifre = textBox2.Text;

                baglanti.Open();
                OleDbCommand kaydet = new OleDbCommand("UPDATE welcome set  pass = '" + sifre + "' where user='" + textBox1.Text + "'", baglanti);
                kaydet.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Programa Şifre Koyuldu");
                baglanti.Close();
            }
            catch (Exception hata)
            {
                label3.Text = "Hata! " + hata.Message;
            }
            finally
            {
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox tbox = (TextBox)item;
                        tbox.Clear();
                    }
                }
                baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("select * from welcome where user='" + textBox1.Text + "'", baglanti);
                OleDbDataReader veriler = sorgu.ExecuteReader();

                while (veriler.Read())
                {
                    textBox2.Text = veriler["pass"].ToString();
                    textBox2.Clear();
                }
                sorgu.Dispose();
                baglanti.Close();
            }
            catch (Exception hata)
            {
                label3.Text = "Hata! " + hata.Message;
            }
            finally
            {
                baglanti.Close();
            }

            if (textBox1.TextLength == 18)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.TextLength == 8)
            {
                e.Handled = true;
                label3.Text = "Şifreniz En Fazla 8 Karakter Uzunluğunda Olmalı";
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

        private void Form5_Load(object sender, EventArgs e)
        {
            CancelButton = button1;
        }
    }
}
