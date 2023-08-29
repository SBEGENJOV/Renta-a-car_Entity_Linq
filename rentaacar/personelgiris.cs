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
    public partial class personelgiris : Form
    {
        retnacarEntities1 conn = new retnacarEntities1();
        public personelgiris()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 fgec = new Form1();
            fgec.Show();
            this.Hide();
        }

        public bool loginUser(string userName, string passw)
        {
            var query = from user in conn.personels
                        where user.perNameSurname == userName && user.perNameSurname == passw
                        select user;
            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (loginUser(textBox1.Text, textBox2.Text))
            {
                Form1 go = new Form1();
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
