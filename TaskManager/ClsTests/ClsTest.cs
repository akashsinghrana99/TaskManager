using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager.ClsTests
{
    public class ClsTest
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public bool AddTest(TaskModel obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("AddTask", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", obj.title);
                cmd.Parameters.AddWithValue("@description", obj.description);
                cmd.Parameters.AddWithValue("@due_date", obj.due_date);
                cmd.Parameters.AddWithValue("@remarks", obj.remarks);
                cmd.Parameters.AddWithValue("@created_by", obj.created_by);
                cmd.Parameters.AddWithValue("@updated_by", obj.updated_by);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetTask()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("GetTask", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }



            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool DeleteTest(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DeleteTask", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if(i>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool UpdateTest(TaskModel obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("updateTask", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", obj.id);
                cmd.Parameters.AddWithValue("@title", obj.title);
                cmd.Parameters.AddWithValue("@description", obj.description);
                cmd.Parameters.AddWithValue("@due_date", obj.due_date);
                cmd.Parameters.AddWithValue("@remarks", obj.remarks);

                int i = cmd.ExecuteNonQuery();
                con.Close();
                if(i>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}