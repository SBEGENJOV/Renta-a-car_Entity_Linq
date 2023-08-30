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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource=conn.cars.ToList();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            custumer kullanici=new custumer();
            dataGridView1.DataSource = conn.custumers.ToList();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = conn.branches.ToList();
        }
        
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = conn.personels.ToList();
        }
        
        private void personel_page_Load(object sender, EventArgs e)
        {
            
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
    }
}
