using System.Data;
using System.Data.SqlClient;
namespace TalukMaster.Datalayer
{
    public class dbclass
    {
        public string conn = string.Empty;

        public dbclass() 
        { 
            var connString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["dbcs"];
            conn = Convert.ToString(connString);
        }

        public DataTable GetDataTable(string query)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection sqlConn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tblData = new DataTable();

            cmd.CommandText = query;
            sqlConn.ConnectionString = conn;
            sqlConn.Open();
            cmd.Connection = sqlConn;
            cmd.CommandType = CommandType.Text;
            da.SelectCommand = cmd;
            da.Fill(tblData);
            sqlConn.Close();
            return tblData;
        }

        public int ExecuteOnlyQuery(string query)
        {
            SqlConnection sqlConn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = query;
            sqlConn.ConnectionString = conn;
            sqlConn.Open();
            cmd.Connection = sqlConn;
            cmd.CommandType = CommandType.Text;
            int count = cmd.ExecuteNonQuery();
            sqlConn.Close();
            return count;
        }

        public int ExecuteScalar(SqlCommand cmd)
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = conn;
            sqlConn.Open();
            cmd.Connection = sqlConn;
            cmd.CommandType = CommandType.Text;
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            sqlConn.Close();
            return count;
        }


        public decimal ExecuteScalarDecimal(SqlCommand cmd)
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = conn;
            sqlConn.Open();
            cmd.Connection = sqlConn;
            cmd.CommandType = CommandType.Text;
            decimal count = cmd.ExecuteScalar() == DBNull.Value ? Convert.ToDecimal(0.00) : Convert.ToDecimal(cmd.ExecuteScalar());
            sqlConn.Close();
            return count;
        }


    }
}
