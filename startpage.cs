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
    public partial class startpage : Form
    {
        public startpage()
        {
            InitializeComponent();
        }
        Timer tmr;
        private void startpage_Load(object sender, EventArgs e)
        {
            tmr = new Timer();
            //set time interval 5 sec
            tmr.Interval = 5000;
            //starts the timer
            tmr.Start();
            tmr.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
            tmr.Stop();
            //display mainform
            loginform mf = new loginform();
            mf.Show();
            //hide this form
            this.Hide();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        

    }
}
