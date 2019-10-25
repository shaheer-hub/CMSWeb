using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Helpers
{
    public class SqlDbHelper
    {
        const string ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=CMS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\CMS.mdf";
        public static DataTable ExecuteParameterizedSelectCommand(CommandType commandType , string commandText, params SqlParameter[] commandParameters)
        {
            DataTable table = null;
            SqlCommand cmd;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                cmd = new SqlCommand();

                try
                {
                    MakeCommand(cmd, con, null, commandType, commandText, commandParameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        table = new DataTable();
                        da.Fill(table);
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return table;
            
        }
        //public static object ExecuteDataSet(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataAdapter adpt = new SqlDataAdapter();
        //    DataSet ds = new DataSet();
        //    using (SqlConnection conn = new SqlConnection(ConnectionString))
        //    {
        //        PrepareCommand(cmd, conn, null, commandType, commandText, commandParameters);
        //        adpt.SelectCommand = cmd;
        //        adpt.Fill(ds);
        //        cmd.Parameters.Clear();

        //        return ds;
        //    }
        //}
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        public static DataTable ExecuteSelectCommand(CommandType commandType, string commandText)
        {
            DataTable table = null;
            SqlCommand cmd;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                cmd = new SqlCommand();

                try
                {
                    MakeCommand(cmd, con, null, commandType, commandText, null);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        table = new DataTable();
                        da.Fill(table);
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }


            }
            return table;

        }
        public static bool ExecuteNonQuery(CommandType commandType , string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd;
            int result;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                cmd = new SqlCommand();
                try
                {
                    cmd = MakeCommand(cmd, con, null, commandType, commandText, commandParameters);
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return (result > 0);
        }
        public static SqlCommand MakeCommand(SqlCommand cmd, SqlConnection con , SqlTransaction trans , CommandType cmdType , string cmdText , SqlParameter[] cmdParms)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.Connection = con;
            cmd.CommandText = cmdText;
            if(trans != null)
            {
                cmd.Transaction = trans;
            }

            cmd.CommandType = cmdType;
            if(cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
            return cmd;
        }
    }
}
