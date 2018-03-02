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
    public partial class insertform : Form
    {
        insert i = new insert();
        public insertform()
        {
            InitializeComponent();
        }
        returnclass r = new returnclass();
        private void button1_Click(object sender, EventArgs e)
        {

            student s = new student();

         //  s.sfk = Form1.fk_ad;
            s.sfk = "1";
           s.sdate = System.DateTime.Now.ToShortDateString();
           s.sname = textBox1.Text;
            s.sfname = textBox2.Text;
            if (radioButton1.Checked==true)
            {
                s.sgender = "male";
            }
            else if (radioButton2.Checked==true)
            {
                s.sgender = "female";
            }
            else
            {
                MessageBox.Show("Please select gender!");
            }
            s.saddress = richTextBox1.Text;


            
           MessageBox.Show (i.insert_srecord(s));


           
           student_status sa = new student_status();
           sa.year = System.DateTime.Now.Year.ToString();
           sa.class_id = Convert.ToInt16(comboBox1.SelectedValue.ToString());
           sa.status_student_id = Convert.ToInt32(r.scalarReturn("select max(std_id) from student"));

           i.insert_StudentStatus(sa);

        textBox5.Text= r.scalarReturn("select  max(std_id) from student");

        textBox4.Text = textBox5.Text;





        } //submit tbn ends

        private void button2_Click(object sender, EventArgs e)
        {
                
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
               
                pictureBox1.Image = new Bitmap(open.FileName);
               
                textBox3.Text = open.FileName;
            }


           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            std_imgclass img = new std_imgclass();
            img.s_id = Convert.ToInt32 (textBox4.Text);
            img.img_path = textBox3.Text;
            i.insert_img(img);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            richTextBox1.Clear();
           

        }

        private void insertform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'schoolmDataSet1.classes' table. You can move, or remove it, as needed.
            this.classesTableAdapter1.Fill(this.schoolmDataSet1.classes);
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            returnclass r = new returnclass();
            student_status sa = new student_status();
            sa.year = System.DateTime.Now.Year.ToString();
            sa.class_id =Convert.ToInt16(comboBox1.SelectedValue.ToString());
            sa.status_student_id = Convert.ToInt32(textBox5.Text);
           
            i.insert_StudentStatus(sa);





        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

       
    }
}
