using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace rentaacar
{
    public partial class personel_page : Form
    {
        retnacarEntities1 conn = new retnacarEntities1();
        car araba = new car();
        custumer kullanici = new custumer();
        personel calisan = new personel();
        branch sube = new branch();
        public personel_page()
        {
            InitializeComponent();
        }
        int tutucu;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            tutucu = 2;
            dataGridView1.DataSource=conn.cars.ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            tutucu = 1;
            dataGridView1.DataSource = conn.custumers.ToList();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = conn.branches.ToList();
        }
        
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            tutucu = 3;
            dataGridView1.DataSource = conn.personels.ToList();
        }
        
        private void personel_page_Load(object sender, EventArgs e)
        {
            var query = (from x in conn.cars
                         select new { x.carNo });
            comboBox3.DataSource = query.ToList();
            comboBox3.DisplayMember = "carNo";
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible=false;
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {
            var query = (from urun in conn.custumers
                         select urun.custumerID).Count();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Müşteri Toplamı", typeof(int));
            dataTable.Rows.Add(query);
            dataGridView1.DataSource = dataTable;
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            var query = from c1 in conn.cars
                        join b1 in conn.branches on c1.branchNo equals b1.branchNo
                        group b1 by new { c1.branchNo, b1.branchName } into subeArac
                        select new
                        {
                            ŞubeAd = subeArac.Key.branchName,
                            AraçSayısı = subeArac.Count()
                        };
            
            dataGridView1.DataSource = query.ToList();
        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {
            var query = (from urun in conn.cars
                         select urun.carNo).Count();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Araçların Toplamı", typeof(int));
            dataTable.Rows.Add(query);
            dataGridView1.DataSource = dataTable;
        }

        private void simpleButton23_Click(object sender, EventArgs e)
        {
            var query = (from urun in conn.cars
                         select urun.carPrice).Sum();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Araçların toplam ücreti", typeof(int));
            dataTable.Rows.Add(query);
            dataGridView1.DataSource = dataTable;
        }

        private void simpleButton38_Click(object sender, EventArgs e)
        {
            var query = from sube in conn.branches
                        group sube by new
                        {
                            sube.branchEmployee,
                            sube.branchName
                        }into subeCalısan 
                        orderby subeCalısan.Key.branchEmployee descending
                        select new
                        {
                            SubeAd=subeCalısan.Key.branchName,
                            SubeCalisanSayı=subeCalısan.Key.branchEmployee
                        };

            dataGridView1.DataSource = query.ToList();
        }

        private void simpleButton25_Click(object sender, EventArgs e)
        {
            var query= (from myas in conn.custumers
                       select myas.custumerAge).Average();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Müşterilerin Yaş Ortalaması", typeof(int));
            dataTable.Rows.Add(query);
            dataGridView1.DataSource = dataTable;
        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            var query = (from myas in conn.custumers
                         select myas.custumerBalance).Sum();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Müşteri Ödemelerinin Toplamı", typeof(int));
            dataTable.Rows.Add(query);
            dataGridView1.DataSource = dataTable;
        }

        private void simpleButton26_Click(object sender, EventArgs e)
        {
            var query = (from myas in conn.custumers
                         select myas.custumerBalance).Sum();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Müşteri Depositlerinin Toplamı", typeof(int));
            dataTable.Rows.Add(query);
            dataGridView1.DataSource = dataTable;
        }

        private void simpleButton27_Click(object sender, EventArgs e)
        {
            var query = (from acar in conn.cars
                         select acar.carYear.Value.Year).Average();


            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Araçların Yıllarının Ortalaması", typeof(int));
            dataTable.Rows.Add(query);
            dataGridView1.DataSource = dataTable;
        }

        private void simpleButton37_Click(object sender, EventArgs e)
        {
            var query = (from ncar in conn.cars
                         orderby ncar.carYear
                         select ncar).Take(1);

            dataGridView1.DataSource = query.ToList();
        }

        private void simpleButton30_Click(object sender, EventArgs e)
        {
            var query = (from pcar in conn.cars
                         orderby pcar.carPrice
                         select pcar).Take(1);

            dataGridView1.DataSource = query.ToList();
        }

        private void simpleButton31_Click(object sender, EventArgs e)
        {
            var query = (from bbra in conn.branches
                         orderby bbra.branchRevenue
                         select bbra).Take(1);

            dataGridView1.DataSource = query.ToList();
        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {
            var query = (from ycus in conn.custumers
                         orderby ycus.custumerAge
                         select ycus).Take(1);

            dataGridView1.DataSource = query.ToList();
        }

        private void simpleButton28_Click(object sender, EventArgs e)
        {
            var query = (from sper in conn.personels
                         orderby sper.perSalary
                         select sper).Take(1);

            dataGridView1.DataSource = query.ToList();
        }

        private void simpleButton36_Click(object sender, EventArgs e)
        {
            var query = (from dCus in conn.custumers
                         orderby dCus.custumerDeposit
                         select dCus).Take(1);

            dataGridView1.DataSource = query.ToList();
        }

        private void simpleButton34_Click(object sender, EventArgs e)
        {
            var query = (from scar in conn.cars
                         orderby scar.carMotor
                         select scar).Take(1);

            dataGridView1.DataSource = query.ToList();
        }

        private void simpleButton35_Click(object sender, EventArgs e)
        {
            var query = from ccar in conn.cars
                        group ccar by ccar.carColor into subeCalısan
                        orderby  subeCalısan.Count() descending
                        select new
                        {
                            AracModel = subeCalısan.Key,
                            AracRenk = subeCalısan.Count()
                        };

            dataGridView1.DataSource = query.ToList();
        }

        private void simpleButton33_Click(object sender, EventArgs e)
        {
            var query = (from scar in conn.cars
                         orderby scar.carPrice descending
                         select scar).Take(1);

            dataGridView1.DataSource = query.ToList();
        }

        private void simpleButton32_Click(object sender, EventArgs e)
        {
            var query = (from scar in conn.cars
                         orderby scar.carPrice
                         select scar).Take(1);

            dataGridView1.DataSource = query.ToList();
        }
        
        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            var query = from c in conn.cars
                        select new { c.carNo, c.carModel, c.carPlaque };

            DataTable dt = new DataTable();
            dt.Columns.Add("carNo"); // Sütunları ekleyin
            dt.Columns.Add("carModel");
            dt.Columns.Add("carPlaque");

            foreach (var item in query)
            {
                DataRow newRow = dt.NewRow();
                newRow["carNo"] = item.carNo;
                newRow["carModel"] = item.carModel;
                newRow["carPlaque"] = item.carPlaque;
                dt.Rows.Add(newRow);
            }

            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("carModel LIKE '%{0}%'", textBox20.Text);
            dataGridView1.DataSource = dv;
        }

        private void textBox20_Click(object sender, EventArgs e)
        {
            textBox20.Text = "";
        }
        private void simpleButton16_Click(object sender, EventArgs e)
        {
            var query = (from c in conn.personels
                         where c.perNameSurname == textBox15.Text
                         select c);
            dataGridView1.DataSource= query.ToList();
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            var query= (from c in conn.custumers
                       where c.custumerName==textBox1.Text
                       select c);
            dataGridView1.DataSource = query.ToList();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            custumer custumer = new custumer();
            int ID = Convert.ToInt32(textBox1.Tag);
            var query=(from kgun in conn.custumers
                      where kgun.custumerID==ID
                      select kgun).FirstOrDefault();
            query.custumerName = textBox1.Text;
            query.custumerPhone = textBox2.Text;
            query.custumerAge = int.Parse(textBox3.Text);
            query.custumerBalance = decimal.Parse(textBox4.Text);
            query.custumerDeposit = decimal.Parse(textBox5.Text);
            query.carNo = int.Parse(comboBox3.Text);
            conn.SaveChanges();
            MessageBox.Show("Kullanıcı Güncellendi");
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            custumer custumer = new custumer();
            custumer.custumerName = textBox1.Text;
            custumer.custumerPhone= textBox2.Text;
            custumer.custumerAge = int.Parse(textBox3.Text);
            custumer.custumerBalance = int.Parse(textBox4.Text);
            custumer.custumerDeposit = int.Parse(textBox5.Text);
            custumer.carNo= int.Parse(comboBox3.Text);
            conn.custumers.Add(custumer);
            conn.SaveChanges();
            MessageBox.Show("Araç Kiralandı");

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            custumer custumer = new custumer();
            int ID = Convert.ToInt32(textBox1.Tag);
            var query= (from ksil in conn.custumers
                       where ksil.custumerID == ID
                       select ksil).FirstOrDefault();
            conn.custumers.Remove(query);
            conn.SaveChanges();
            MessageBox.Show("Kullanıcı Silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            if (tutucu==1)
            {
                textBox1.Tag = satir.Cells["custumerID"].Value.ToString();
                textBox1.Text = satir.Cells["custumerName"].Value.ToString();
                textBox2.Text = satir.Cells["custumerPhone"].Value.ToString();
                textBox3.Text = satir.Cells["custumerAge"].Value.ToString();
                textBox4.Text = satir.Cells["custumerBalance"].Value.ToString();
                textBox5.Text = satir.Cells["custumerDeposit"].Value.ToString();
                comboBox3.Text = satir.Cells["carNo"].Value.ToString();
            }
            else if (tutucu == 2)
            {
                textBox7.Tag = satir.Cells["carNo"].Value.ToString();
                textBox7.Text = satir.Cells["carPrice"].Value.ToString();
                textBox8.Text = satir.Cells["carPlaque"].Value.ToString();
                textBox9.Text = satir.Cells["carModel"].Value.ToString();
                maskedTextBox1.Text = satir.Cells["carYear"].Value.ToString();
                textBox11.Text = satir.Cells["carMotor"].Value.ToString();
                textBox12.Text = satir.Cells["carPacet"].Value.ToString(); 
                textBox13.Text = satir.Cells["carColor"].Value.ToString();
                textBox14.Text = satir.Cells["carTransmission"].Value.ToString();
                comboBox1.Text = satir.Cells["branchNo"].Value.ToString();
            }
            else if (tutucu == 3)
            {
                textBox15.Tag = satir.Cells["perNo"].Value.ToString();
                textBox15.Text = satir.Cells["perNameSurname"].Value.ToString();
                textBox16.Text = satir.Cells["perTel"].Value.ToString();
                textBox17.Text = satir.Cells["perTitle"].Value.ToString();
                textBox18.Text = satir.Cells["perMail"].Value.ToString();
                textBox19.Text = satir.Cells["perSalary"].Value.ToString();
                comboBox2.Text= satir.Cells["branchNo"].Value.ToString();
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            car araba = new car();
            araba.carPrice =Convert.ToDecimal(textBox7.Text);
            araba.carPlaque =textBox8.Text;
            araba.carModel = textBox9.Text;
            araba.carYear =Convert.ToDateTime(maskedTextBox1.Text);
            araba.carMotor = textBox11.Text;
            araba.carPacet = textBox12.Text;
            araba.carColor = textBox13.Text;
            araba.carTransmission =Convert.ToInt32(textBox14.Text);
            araba.branchNo =Convert.ToInt32(comboBox1.Text);
            conn.cars.Add(araba);
            conn.SaveChanges();
            MessageBox.Show("Araç Eklendi");
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            int ID =Convert.ToInt32(textBox7.Tag);
            var query=(from cDel in conn.cars
                      where cDel.carNo==ID
                      select cDel).FirstOrDefault();
            conn.cars.Remove(query);
            conn.SaveChanges();
            MessageBox.Show("Araç Silindi");
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox7.Tag);
            var query=(from cUpd in conn.cars
                      where cUpd.carNo==ID
                      select cUpd).FirstOrDefault();
            query.carPrice =Convert.ToDecimal(textBox7.Text);
            query.carPlaque=textBox8.Text;
            query.carModel=textBox9.Text;
            query.carYear = Convert.ToDateTime(maskedTextBox1.Text);
            query.carMotor = textBox11.Text;
            query.carPacet = textBox12.Text;
            query.carColor = textBox13.Text;
            query.carTransmission = Convert.ToInt32(textBox14.Text);
            query.branchNo=Convert.ToInt32(comboBox1.Text);
            conn.SaveChanges();
            MessageBox.Show("Kullanıcı Güncellendi");
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            personel calisan = new personel();
            calisan.perNameSurname=textBox15.Text;
            calisan.perTel=textBox16.Text;
            calisan.perTitle=textBox17.Text;
            calisan.perMail=textBox18.Text;
            calisan.perSalary =Convert.ToDecimal(textBox19.Text);
            calisan.branchNo =Convert.ToInt32(comboBox2.Text);

            conn.personels.Add(calisan);
            conn.SaveChanges();
            MessageBox.Show("Personel Eklendi");
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox15.Tag);
            var query= (from pDel in conn.personels
                       where pDel.perNo== ID
                       select pDel).FirstOrDefault();
            conn.personels.Remove(query);
            conn.SaveChanges();
            MessageBox.Show("Personel silindi");
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox15.Tag);
            var query = (from pUpd in conn.personels
                         where pUpd.perNo == ID
                         select pUpd).FirstOrDefault();
            query.perNameSurname = textBox15.Text;
            query.perTel = textBox16.Text;
            query.perTitle = textBox17.Text;
            query.perMail = textBox18.Text;
            query.perSalary = Convert.ToDecimal(textBox19.Text);
            query.branchNo = Convert.ToInt32(comboBox2.Text);
            conn.SaveChanges();
            MessageBox.Show("Personel Güncellendi");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form1 fgec = new Form1();
            fgec.Show();
            this.Hide();
        }
    }
}
