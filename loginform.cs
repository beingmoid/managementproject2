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
    public partial class loginform : Form
    {

        public static string fk_ad;
        public loginform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightSkyBlue;
            string user = textBox1.Text;
            string password =pass1.Text;
            string userdb, passworddb;

            returnclass rc = new returnclass();
            userdb = rc.scalarReturn("select count(ad_id) from administator where ad_name='" + user + "'");


            if (userdb.Equals("0"))
            {
                MessageBox.Show("Invalid user name!");
            }
            else
            {
                passworddb = rc.scalarReturn("select ad_password from administator where ad_name='" + user + "'");

                if (passworddb.Equals(password))
                {
                    fk_ad = rc.scalarReturn("select ad_id from administator where ad_name='" + user + "'");

                    Dashboard f = new Dashboard();
                    f.Show();

                }
                else
                {
                    MessageBox.Show("Invalid Password!");
                }


            }


        }

        private void loginform_Load(object sender, EventArgs e)
        {

        }
        }
    }

