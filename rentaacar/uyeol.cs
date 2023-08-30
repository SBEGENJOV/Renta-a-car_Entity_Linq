using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rentaacar
{
    public partial class uyeol : Form
    {
        public uyeol()
        {
            InitializeComponent();
        }
        retnacarEntities1 conn = new retnacarEntities1();
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 fgec = new Form1();
            fgec.Show();
            this.Hide();
        }
        public static int deger;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            custumer custumerr = new custumer();
            var ktel = (from cus in conn.custumers
                       where cus.custumerPhone==textBox2.Text
                       select cus.custumerPhone).FirstOrDefault();
                //conn.custumers.Where(a => a.custumerPhone == textBox2.Text);
            if (ktel!=null)
            {
                MessageBox.Show("Bu telefon numarası ile zaten hesap oluşturuldu");
            }
            else
            {
                custumerr.custumerName = textBox1.Text;
                custumerr.custumerPhone = textBox2.Text;
                custumerr.custumerAge = int.Parse(textBox3.Text);
                custumerr.custumerBalance = decimal.Parse(textBox4.Text);
                custumerr.custumerDeposit = decimal.Parse(textBox5.Text);
                conn.custumers.Add(custumerr);
                conn.SaveChanges();
                MessageBox.Show("Üyelik Tamamlandı Tekrar Giriş Yapın");
                Form1 fgec = new Form1();
                fgec.Show();
                this.Hide();
               
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 fgec = new Form1();
            fgec.Show();
            this.Hide();
        }
    }
}
