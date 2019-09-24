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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=muhasebe.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string user = textBox1.Text;
                string pass = textBox2.Text;

                baglanti.Open();
                OleDbCommand kaydet = new OleDbCommand("INSERT INTO sign_in (user,pass) values('" + user + "','" + pass + "')", baglanti);
                kaydet.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Kullanıcı Adı Ve Şifre Koyuldu");
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata! " + hata.Message);
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
    }
}
