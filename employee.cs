using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;
using WindowsFormsApplication4;

namespace student
{
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }
       // string connectionstring = "yahan par apny connrction ki details dy dy na";
        private string connectionstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;
      
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGreen;
            if ((this.textBox6.Text.ToString() == "") || (this.textBox3.Text.ToString() == "") || (this.dateTimePicker1.Text.ToString() == "") || (this.dateTimePicker2.Text.ToString() == "") || (this.textBox13.Text.ToString() == "") || (this.comboBox1.Text.ToString() == "") || (this.textBox27.Text.ToString() == "") || (this.textBox21.Text.ToString() == "") || (this.textBox22.Text.ToString() == "") || (this.comboBox3.Text.ToString() == ""))
            {
                MessageBox.Show("Please fill all fields");
            }
            else
            {
                string Query = "insert into employee([emp_name],[emp_f_name],[emp_joiningdate]," +
                  "[emp_dob],[emp_qualification],[emp_nic],[emp_gender],[emp_addrees],[emp_contactno]," +
                  "[emp_email],[emp_category])" +
   "values('" + this.textBox6.Text + "','" + this.textBox3.Text + "','" + this.dateTimePicker1.Text + "'," +
           "'" + this.dateTimePicker2.Text + "','" + this.textBox13.Text + "','" + this.textBox7.Text + "','" + this.comboBox1.Text + "','" + this.textBox27.Text + "','" + this.textBox21.Text + "','" + this.textBox22.Text + "','" + this.comboBox3.Text + "' )";


                SqlConnection condatabase = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand(Query, condatabase);
                SqlDataReader myReader;
                try
                {
                    condatabase.Open();
                    myReader = cmd.ExecuteReader();
                    MessageBox.Show("New Employee Record Saved");
                    // employee el = new employee();
                    this.textBox6.Text = "";
                    this.textBox3.Text = "";
                    this.textBox13.Text = "";
                    this.textBox21.Text = "";
                    this.textBox22.Text = "";
                    this.textBox27.Text = "";
                    this.textBox7.Text = "";
                    this.dateTimePicker2.Text = "";
                    this.dateTimePicker1.Text = "";
                    this.comboBox1.Text = "";
                    this.comboBox3.Text = "";


                    while (myReader.Read())
                    {
                        myReader.ToString();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void employee_Load(object sender, EventArgs e)
        {

        }

        private void show_Click(object sender, EventArgs e)
        {
           
           string Query = "SELECT * FROM employee";

            SqlConnection condatabase = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(Query, condatabase);
            SqlDataAdapter adatper = new SqlDataAdapter();
            adatper.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adatper.Fill(dt);

            //SqlDataReader myReader;
            try
            {
                condatabase.Open();
                dataGridView1.DataSource = dt;
               
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
           
            string Query = "DELETE FROM employee WHERE emp_id = 20";
            SqlConnection condatabase = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(Query, condatabase);
            SqlDataReader myReader;
            condatabase.Open();
            myReader = cmd.ExecuteReader();
            MessageBox.Show("Record deleted");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
