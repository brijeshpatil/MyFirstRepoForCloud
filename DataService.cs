using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace WebApplication1
{
    public class DataService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;

        public DataTable GetALlUSer()
        {
            da = new SqlDataAdapter("GetALlUSer", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void DeleteUser(int UserID)
        {
            cmd = new SqlCommand("DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UID", UserID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertNewUser(PService P)
        {
            cmd = new SqlCommand("InsertNewUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FName", P.FirstName);
            cmd.Parameters.AddWithValue("@LName", P.LastName);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateUser(PService P)
        {
            cmd = new SqlCommand("UpdateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UID", P.UserID);
            cmd.Parameters.AddWithValue("@FName", P.FirstName);
            cmd.Parameters.AddWithValue("@LName", P.LastName);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}