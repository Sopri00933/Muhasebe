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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=muhasebe.accdb Persist Security Info=True");
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap = new DialogResult();
            cevap = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int banka_hesabi = Convert.ToInt32(textBox1.Text);
                int dis = Convert.ToInt32(textBox2.Text);
                int dolar = Convert.ToInt32(textBox3.Text);
                int euro = Convert.ToInt32(textBox4.Text);
                int vergi_borcu = Convert.ToInt32(textBox6.Text);
                string tarih = dateTimePicker1.Text;

                baglanti.Open();
                OleDbCommand kaydet = new OleDbCommand("insert into hesaplar(banka_hesabi,dis,dolar,euro,vergi_borcu,tarih) values('" + banka_hesabi + "','" + dis + "','" + dolar + "','" + euro + "','" + vergi_borcu + "','" + tarih + "')", baglanti);
                kaydet.ExecuteNonQuery();

                baglanti.Close();
                MessageBox.Show("Kayıt işlemi başarılı");
                baglanti.Close();
            }
            catch (Exception hata)
            {
                label6.Text = "Hata! " + hata.Message;
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text.Trim() == "") 
                errorProvider1.SetError(textBox1, "Banka Hesabını Boş Bırakmayınız");
       
            else
                errorProvider1.SetError(textBox1, "");
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text.Trim() == "")
                errorProvider1.SetError(textBox2, "Dış Gücü Boş Bırakmayınız");

            else
                errorProvider1.SetError(textBox2, "");
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text.Trim() == "")
                errorProvider1.SetError(textBox3, "Doları Boş Bırakmayınız");

            else
                errorProvider1.SetError(textBox3, "");
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {

            if (textBox4.Text.Trim() == "")
                errorProvider1.SetError(textBox4, "Euroyu Boş Bırakmayınız");

            else
                errorProvider1.SetError(textBox4, "");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AcceptButton = button1;
            AcceptButton = button2;
            CancelButton = button3;
            AcceptButton = button4;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          try
            {
                if (char.IsLetter(e.KeyChar)) 
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == (char)13) 
                {

                    Double birimfiyat = Convert.ToDouble(textBox1.Text);
                    textBox1.Text = string.Format("{0:c}", double.Parse(textBox1.Text));
                }
            }
            catch (Exception)
            {

                MessageBox.Show("BİRİM FİYAT GEÇERSİZ");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == (char)13)
                {

                    Double birimfiyat = Convert.ToDouble(textBox2.Text);
                    textBox2.Text = string.Format("{0:c}", double.Parse(textBox2.Text));
                }
            }
            catch (Exception)
            {

                MessageBox.Show("BİRİM FİYAT GEÇERSİZ");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == (char)13)
                {

                    Double birimfiyat = Convert.ToDouble(textBox3.Text);
                    textBox3.Text = string.Format("{0:c}", double.Parse(textBox3.Text));
                }
            }
            catch (Exception)
            {

                MessageBox.Show("BİRİM FİYAT GEÇERSİZ");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == (char)13)
                {

                    Double birimfiyat = Convert.ToDouble(textBox4.Text);
                    textBox4.Text = string.Format("{0:c}", double.Parse(textBox4.Text));
                }
            }
            catch (Exception)
            {

                MessageBox.Show("BİRİM FİYAT GEÇERSİZ");
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == (char)13)
                {

                    Double birimfiyat = Convert.ToDouble(textBox6.Text);
                    textBox6.Text = string.Format("{0:c}", double.Parse(textBox6.Text));
                }
            }
            catch (Exception)
            {

                MessageBox.Show("BİRİM FİYAT GEÇERSİZ");
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text.Trim() == "")
                errorProvider1.SetError(textBox6, "Vergi Borcunu Boş Bırakmayınız");

            else
                errorProvider1.SetError(textBox6, "");
        }
    }
}
