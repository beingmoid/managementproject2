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
    public partial class viewform : Form
    {
        viewclass vc = new viewclass();
        string q;
        public viewform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGreen;
            q = "select s.std_id as 'id',s.std_name as 'Name',s.std_fname AS 'Father name',s.std_gender as 'Gender',s.std_address as 'Address',s.std_admissiondate as 'Admission Date' ,a.ad_name as 'Admin Name' from student s inner join administator a on a.ad_id=s.std_ad_fk_id where s.std_id=" + textBox2.Text;
            dataGridView1.DataSource = vc.showrecord(q);

            returnclass rc = new returnclass();
          string pathquerry=  rc.scalarReturn("select img_path from student_img where img_fk="+textBox2.Text);
          if (pathquerry==" ")
          {
              pictureBox1.Image = Image.FromFile(@"C:\Users\salman\documents\visual studio 2013\Projects\WindowsFormsApplication4\WindowsFormsApplication4\Resources\profile.jpg");
          }
          else
          {
              pictureBox1.Image = Image.FromFile(pathquerry);
          }
         
          pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            

        }

        private void viewform_Load(object sender, EventArgs e)
        {
            q = "select s.std_id as 'id',s.std_name as 'Name',s.std_fname AS 'Father name',s.std_gender as 'Gender',s.std_address as 'Address',s.std_admissiondate as 'Admission Date' ,a.ad_name as 'Admin Name' from student s inner join administator a on a.ad_id=s.std_ad_fk_id";
            dataGridView1.DataSource = vc.showrecord(q);

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            q = "select s.std_id as 'id',s.std_name as 'Name',s.std_fname AS 'Father name',s.std_gender as 'Gender',s.std_address as 'Address',s.std_admissiondate as 'Admission Date' ,a.ad_name as 'Admin Name' from student s inner join administator a on a.ad_id=s.std_ad_fk_id where s.std_name like '" + textBox1.Text + "%'";
            dataGridView1.DataSource = vc.showrecord(q);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightSkyBlue;
            textBox1.Clear();
            textBox2.Clear();
            
        }
        
    }
}
