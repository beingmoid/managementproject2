using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class feessubmission : Form
    {
        viewclass vc = new viewclass();
        returnclass rc = new returnclass();
        string q;
        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;
        public feessubmission()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSteelBlue;
            SqlConnection connection = new SqlConnection(connstring);
            string sql = "select s.std_id,s.std_name,sa.SA_ID,SA_Class_id,sa.sa_year,c.classname,c.fees  from student s inner join STUDENT_STATUS sa  on sa.SA_ST_ID=s.std_id inner join classes c on c.class_id=sa.SA_Class_id where sa.sa_year='"+System.DateTime.Now.Year+"' and s.std_id="+textBox1.Text;

            try
            {
                label2.Text = " ";
                label3.Text = " ";
                label4.Text = " ";
                label5.Text = " ";

                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    button2.Enabled = true;


                    while (reader.Read())
                    {
                        label2.Text = reader.GetValue(1).ToString();
                        label3.Text = reader.GetValue(5).ToString();
                        label4.Text = reader.GetValue(6).ToString();
                        label5.Text = reader.GetValue(2).ToString();



                    }



                   
                    string pathquerry = rc.scalarReturn("select img_path from student_img where img_fk=" + textBox1.Text);
                    if (pathquerry == " ")
                    {
                        pictureBox1.Image = Image.FromFile(@"C:\Users\salman\documents\visual studio 2013\Projects\WindowsFormsApplication4\WindowsFormsApplication4\Resources\profile.jpg");
                    }
                    else
                    {
                        pictureBox1.Image = Image.FromFile(pathquerry);
                    }

                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    string s = rc.scalarReturn("select count(fee_id) from fees where fee_fk_st_id=" + textBox1.Text + " and monthx='" + System.DateTime.Now.Month.ToString() + "'");
                    if (s.Equals("0"))
                    {
                        button2.Enabled = true;

                        label10.Text = "Unpaid!";
                        label10.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        label10.Text = "paid!";
                        button2.Enabled = false;
                        label10.ForeColor = System.Drawing.Color.Green;

                    }



                }

                else
                {
                    MessageBox.Show("no records were found! ");
                    button2.Enabled = false;

                }

                
               
                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("No RECORDS WERE FOUND!");
            }

           




        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.MediumSpringGreen;
            
            student_status sa = new student_status();
            sa.status_student_id =Convert.ToInt32( label5.Text);
            sa.class_fees = label4.Text;
            sa.class_name = label3.Text;

            insert i = new insert();
            i.insert_FEES(sa, textBox1.Text);
            q = "select s.std_id,sa.SA_ID,f.fee_id,s.std_name,sa.sa_year,f.dayx+'/'+f.monthx as PaidDate,f.fee_amount from student s inner join STUDENT_STATUS sa on s.std_id=sa.SA_ST_ID inner join fees f on sa.SA_ID=f.SA_FK_ID where sa.sa_year='" + System.DateTime.Now.Year.ToString() + "' and f.monthx='" + System.DateTime.Now.Month.ToString() + "'";
            dataGridView1.DataSource = vc.showrecord(q);

            string s = rc.scalarReturn("select count(fee_id) from fees where fee_fk_st_id=" + textBox1.Text + " and monthx='" + System.DateTime.Now.Month.ToString() + "'");
            if (s.Equals("0"))
            {
                button2.Enabled = true;

                label10.Text = "Unpaid!";
                label10.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label10.Text = "paid!";
                button2.Enabled = false;
                label10.ForeColor = System.Drawing.Color.Green;

            }

         




        }

        private void feessubmission_Load(object sender, EventArgs e)
        {
            q = "select s.std_id,sa.SA_ID,f.fee_id,s.std_name,sa.sa_year,f.dayx+'/'+f.monthx as PaidDate,f.fee_amount from student s inner join STUDENT_STATUS sa on s.std_id=sa.SA_ST_ID inner join fees f on sa.SA_ID=f.SA_FK_ID where sa.sa_year='" + System.DateTime.Now.Year.ToString() + "' and f.monthx='" + System.DateTime.Now.Month.ToString() + "' and student_status=1";
            dataGridView1.DataSource = vc.showrecord(q);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            defaulterfrom ft = new defaulterfrom();
            ft.Show();
        }
    }
}
