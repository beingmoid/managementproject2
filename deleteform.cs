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
    public partial class deleteform : Form
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;
        public deleteform()
        {
            InitializeComponent();
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            richTextBox1.Text = " ";








            SqlConnection connection = new SqlConnection(connstring);
            string sql = "select std_name,std_fname,std_gender,std_address,student_status from student where std_id=" + textBox3.Text;

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetValue(4).ToString().Equals("0"))
                    {
                        MessageBox.Show("Student Left!");
                    }
                    else if (reader.GetValue(4).ToString().Equals("1"))
                    {
                        textBox1.Text = reader.GetValue(0).ToString();
                        textBox2.Text = reader.GetValue(1).ToString();
                        if (reader.GetValue(2).ToString().Equals("male"))
                        {
                            radioButton1.Checked = true;
                        }
                        else
                        {
                            radioButton2.Checked = true;
                        }
                        richTextBox1.Text = reader.GetValue(3).ToString();

                        // for image

                        returnclass rc = new returnclass();
                        string pathquerry = rc.scalarReturn("select img_path from student_img where img_fk=" + textBox3.Text);
                        if (pathquerry != " ")
                        {
                            pictureBox1.Image = Image.FromFile(pathquerry);
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        }
                        else
                        {
                            //  pictureBox1.Image = Image.FromFile(@"‪C:\Users\Nida\Desktop\Passportsizephoto.JPG");
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }


                        button1.Enabled = true;

                    }

                    
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No RECORDS WERE FOUND!");
            }












        }

        private void deleteform_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(" "))
            {
                MessageBox.Show("No Records were found");  
       
            }
            else
            {
               
                delete d = new delete();
                string msg = d.delete_srecord(textBox3.Text);
                MessageBox.Show(msg);
                button1.BackColor = Color.Firebrick;
            }
       
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
