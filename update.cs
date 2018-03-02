using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace WindowsFormsApplication4
{
    class update
    {

        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;


        public string update_srecord(student s)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE_STUDENT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@std_id", SqlDbType.Int).Value = s.s_id;
                cmd.Parameters.Add("@std_name", SqlDbType.NVarChar, 20).Value = s.sname;
                cmd.Parameters.Add("@std_fname", SqlDbType.NVarChar, 20).Value = s.sfname;
                cmd.Parameters.Add("@std_gender", SqlDbType.NVarChar, 20).Value = s.sgender;
                cmd.Parameters.Add("@std_address", SqlDbType.NVarChar, 100).Value = s.saddress;
               
               

                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "data successfully updated!";




            }
            catch (Exception)
            {


                msg = "data is not successfully updated!";

            }


            finally
            {
                conn.Close();
            }



            return msg;




        }








    }
}
