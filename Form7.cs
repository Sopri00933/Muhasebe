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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=muhasebe.accdb");
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("select * from welcome where pass='" + textBox1.Text + "'", baglanti);
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
                label2.Text = "Hata! " + hata.Message;
            }
            finally
            {
                if (textBox1.TextLength == 8)
                {
                    e.Handled = true;
                }
                baglanti.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.PasswordChar = '\0';
            }
            else
            {
                textBox1.PasswordChar = '*';
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.TextLength == 8)
            {
                e.Handled = true;
                label2.Text = "Şifreniz En Fazla 8 Karakter Uzunluğunda Olmalı";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string pass = textBox2.Text;

                baglanti.Open();
                OleDbCommand kaydet = new OleDbCommand("UPDATE welcome set  pass = '" + pass + "' where pass='" + textBox1.Text + "'", baglanti);
                kaydet.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Şifre Değiştirildi");
                baglanti.Close();
            }
            catch (Exception hata)
            {
                label2.Text = "Hata! " + hata.Message;
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
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }
    }
}
