using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace rentaacar
{
    public partial class musterigiris : Form
    {
        public static int deger;
        retnacarEntities1 conn = new retnacarEntities1();
        public musterigiris()
        {
            InitializeComponent();
        }
        public bool loginUser(string userName, string passw)
        {
            var query = from user in conn.custumers
                        where user.custumerName == userName && user.custumerPhone == passw
                        select user.custumerID;
            foreach (var firstName in query)
            {
                deger = firstName;
            }
            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 fgec = new Form1();
            fgec.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (loginUser(textBox1.Text, textBox2.Text))
            {
                kullanıci_sayfa go = new kullanıci_sayfa();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("agu bugu");
            }
        }
    }
}
