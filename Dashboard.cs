using student;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            insertform sf= new insertform();
            sf.Show();
        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            feessubmission mi = new feessubmission();
            mi.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            viewform vf = new viewform();
            vf.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            deleteform df = new deleteform();
            df.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

            updateform df =new updateform();
            df.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            insertform st =new insertform();
            st.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void label5_Click(object sender, EventArgs e)
        {
            insertform st = new insertform();
            st.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            viewform vf = new viewform();
            vf.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

            updateform df = new updateform();
            df.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            deleteform df = new deleteform();
            df.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            feessubmission mi = new feessubmission();
            mi.Show();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            employee emp = new employee();
            emp.Show();

        }

        private void label14_Click(object sender, EventArgs e)
        {
            employee emp = new employee();
            emp.Show();

        }
    }
}
