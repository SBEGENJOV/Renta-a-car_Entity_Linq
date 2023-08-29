using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace rentaacar
{
    public partial class kullanıci_sayfa : Form
    {
        retnacarEntities1 conn = new retnacarEntities1();
        public kullanıci_sayfa()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 fgec = new Form1();
            fgec.Show();
            this.Hide();
        }

        private void kullanıci_sayfa_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.cars.ToList();
            tutucu = 1;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.branches.ToList();
            tutucu = 2;
        }
        int tutucu = 0;
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            custumer employe = new custumer();
            var update = conn.custumers.Where(x => x.custumerID == musterigiris.deger).FirstOrDefault();
            update.custumerName = textBox1.Text;
            update.custumerPhone = textBox2.Text;
            update.custumerAge = int.Parse(textBox3.Text);
            conn.SaveChanges();
            dataGridView1.DataSource= conn.custumers.Where(x => x.custumerID == musterigiris.deger).ToList();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            custumer kulanici = new custumer();
            kulanici.custumerID = musterigiris.deger;
            var kad = conn.custumers.Where(x => x.custumerID == musterigiris.deger).Select(a => a.custumerPhone).FirstOrDefault();
            kulanici.custumerName = kad;


            var ktel = conn.custumers.Where(x => x.custumerID == musterigiris.deger).Select(a => a.custumerPhone).FirstOrDefault();
            kulanici.custumerPhone = ktel;


            var kyas = conn.custumers.Where(x => x.custumerID == musterigiris.deger).Select(a => a.custumerAge).FirstOrDefault();
            kulanici.custumerAge = kyas;


            var kbutce = conn.custumers.Where(x => x.custumerID == musterigiris.deger).Select(a => a.custumerBalance).FirstOrDefault();
            kulanici.custumerBalance = kbutce;


            var kdeposit=conn.custumers.Where((x) => x.custumerID == musterigiris.deger).Select(a=>a.custumerDeposit).FirstOrDefault();
            kulanici.custumerDeposit= kdeposit;


            kulanici.carNo = Convert.ToInt32(textBox1.Tag);


            conn.custumers.Add(kulanici);
            conn.SaveChanges();
            int carNoo = Convert.ToInt32(textBox1.Tag);
            dataGridView1.DataSource = conn.cars.Where(x => x.carNo == carNoo).ToList();
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tutucu==1)
            {
                car araba = new car();
                DataGridViewRow satir = dataGridView1.CurrentRow;
                textBox1.Tag = satir.Cells["carNo"].Value.ToString();
                label4.Text = satir.Cells["carModel"].Value.ToString();
                label4.Visible = true;
            }
            else if (tutucu==2)
            {
                branch sube = new branch();
                DataGridViewRow satir = dataGridView1.CurrentRow;
                //textBox1.Tag = satir.Cells["branchNo"].Value.ToString();
            }
            else if (tutucu==3)
            {
                custumer kul=new custumer();
                DataGridViewRow satir = dataGridView1.CurrentRow;
                //textBox1.Tag = satir.Cells["custumerID"].Value.ToString();
                textBox1.Text = satir.Cells["custumerName"].Value.ToString();
                textBox2.Text = satir.Cells["custumerPhone"].Value.ToString();
                textBox3.Text = satir.Cells["custumerAge"].Value.ToString();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            tutucu = 3;
            dataGridView1.DataSource = conn.custumers.Where(x => x.custumerID==(musterigiris.deger)).ToList();
        }
    }
}
