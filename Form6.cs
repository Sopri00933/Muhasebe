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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=muhasebe.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string gsor = comboBox1.Text;
                string cevap = textBox1.Text;
                
                
                baglanti.Open();
                OleDbCommand kaydet = new OleDbCommand("insert into secruity(gsor,cevap) values('" + gsor + "','" + cevap + "')", baglanti);
                kaydet.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Güvenlik Sorusu Koyuldu");
                baglanti.Close();
            }
            catch (Exception hata)
            {
                label5.Text = "Hata! " + hata.Message;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult c;
                c = MessageBox.Show("Şifrenizi Silerseniz Kullanıcı Adınız Devre Dışı Kalacak Şifrenizi Silmek İstediğinizden Eminmisiniz ?", "Uyarı !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    string pass = textBox2.Text;
                    baglanti.Open();
                    OleDbCommand kaydet = new OleDbCommand("delete from welcome where pass='" + pass + "'", baglanti);
                    kaydet.ExecuteNonQuery();
                }
                baglanti.Close();
                if (c == DialogResult.Yes)
                {
                    MessageBox.Show("Şifre Kaldırıldı");
                }
                else
                {
                    MessageBox.Show("Şifre Kaldırma İşlemi İptal Edildi");
                }
                baglanti.Close();
            }
            catch (Exception hata)
            {
                label5.Text = "Hata! " + hata.Message;
            }
            finally
            {
                baglanti.Close();
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
    }
}
