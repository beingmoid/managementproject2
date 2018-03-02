using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class defaulterfrom : Form
    {
        viewclass vc = new viewclass();
        string q;
        public defaulterfrom()
        {
            InitializeComponent();
        }

        private void defaulterfrom_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "1990";
            comboBox2.Text = "1";

            comboBox2.Enabled = false;
            for (int i =1992; i <= System.DateTime.Now.Year; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
            for (int i = 2; i <= 12; i++)
            {
                comboBox2.Items.Add(i.ToString());
            }

            q = "select s.std_id, sa.SA_ID,s.std_gender,s.std_address,c.classname from student s  inner join STUDENT_STATUS sa on s.std_id=sa.SA_ST_ID  inner join classes c on c.class_id=sa.SA_Class_id  where s.std_id not in (select f.fee_fk_st_id from STUDENT_STATUS sa inner join fees f on sa.SA_ID=f.SA_FK_ID where sa.sa_year='" + System.DateTime.Now.Year.ToString() + "' and f.monthx='" + System.DateTime.Now.Month.ToString() + "')";
            dataGridView1.DataSource = vc.showrecord(q);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            q = "select s.std_id, sa.SA_ID,s.std_gender,s.std_address,c.classname from student s  inner join STUDENT_STATUS sa on s.std_id=sa.SA_ST_ID  inner join classes c on c.class_id=sa.SA_Class_id  where s.std_id not in (select f.fee_fk_st_id from STUDENT_STATUS sa inner join fees f on sa.SA_ID=f.SA_FK_ID where sa.sa_year='" + comboBox1.SelectedItem.ToString() + "' and f.monthx='" + comboBox2.SelectedItem.ToString() + "')";
            dataGridView1.DataSource = vc.showrecord(q);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn;
            string connectionString = null;
            string sql = null;
            string data = null;
            int i = 0;
            int j = 0;

            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            connectionString = "Data Source=.;Initial Catalog=schoolm;Integrated Security=True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            sql = q;
            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                    xlWorkSheet.Cells[i + 1, j + 1] = data;
                }
            }

            xlWorkBook.SaveAs(@"C:\Users\Nida\Desktop\dbtoexcel.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created!");
        } //btn event end.....



        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
