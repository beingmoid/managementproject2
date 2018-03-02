using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class viewform2 : Form
    {
        viewclass vc = new viewclass();
        string q;
        public viewform2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            q = "select s.std_id as 'id',s.std_name as 'Name',s.std_fname AS 'Father name',s.std_gender as 'Gender',s.std_address as 'Address',s.std_admissiondate as 'Admission Date' ,a.ad_name as 'Admin Name' from student s inner join administator a on a.ad_id=s.std_ad_fk_id where s.std_id=" + textBox2.Text;
            dataGridView1.DataSource = vc.showrecord(q);
        }

        private void viewform2_Load(object sender, EventArgs e)
        {
            q = "select s.std_id as 'id',s.std_name as 'Name',s.std_fname AS 'Father name',s.std_gender as 'Gender',s.std_address as 'Address',s.std_admissiondate as 'Admission Date' ,a.ad_name as 'Admin Name' from student s inner join administator a on a.ad_id=s.std_ad_fk_id";
            dataGridView1.DataSource = vc.showrecord(q);

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            q = "select s.std_id as 'id',s.std_name as 'Name',s.std_fname AS 'Father name',s.std_gender as 'Gender',s.std_address as 'Address',s.std_admissiondate as 'Admission Date' ,a.ad_name as 'Admin Name' from student s inner join administator a on a.ad_id=s.std_ad_fk_id where s.std_name like '" + textBox1.Text + "%'";
            dataGridView1.DataSource = vc.showrecord(q);

        }
    }
}
