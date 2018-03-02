using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication4
{
    class viewclass
    {

        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;
        public DataTable showrecord(string querry)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(querry, conn);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
                else
                {

                    MessageBox.Show("no records were found!!");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("no records were found!!");
            }

            finally
            {
                conn.Close();
            }
            return dt;
        } //method ends................







    }
}
