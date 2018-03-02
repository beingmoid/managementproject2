using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WindowsFormsApplication4
{
    class delete
    {
        private string connstring = ConfigurationManager.ConnectionStrings["TESTDB"].ConnectionString;



        public string delete_srecord(string id)
        {
            string msg = " ";
            SqlConnection conn = new SqlConnection(connstring);

            try
            {
                SqlCommand cmd = new SqlCommand("student_left", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@std_id", SqlDbType.Int).Value = id;
                

                conn.Open();
                cmd.ExecuteNonQuery();

                msg = "data successfully Deleted!";




            }
            catch (Exception)
            {


//                msg = "data is not successfully Deleted!";

            }


            finally
            {
                conn.Close();
            }



            return msg;




        } //method end......................



    }
}
