﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UberReadingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReadData" in both code and config file together.
    public class ReadData : IReadData
    {

        public DataTable GetHousdetails(string _societyID)
        {
            using (SqlConnection con = new SqlConnection("Data Source= IB-ANBARASU\\SQLSERVER2017; Integrated Security=true;Initial Catalog= designdb; uid=sa; Password=utl@123;"))
            using (SqlCommand cmd = new SqlCommand())
                try
                {
                    using (cmd)
                    {                       
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;//StoredProcedure;
                        cmd.CommandText = "Reading";//"Select * From Graphs Where SocietyID = @SocietyID";
                        cmd.CommandText = "Select * From Graphs Where SocietyID = @SocietyID";
                        cmd.Parameters.Add("@SocietyID", _societyID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable("HouseDetails");
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {

                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }

                    if (con != null)
                    {
                        con.Close();
                        con.Dispose();
                    }

                }
        }

        public DataTable GetHouseDetails()
        {
            //using (SqlConnection con = new SqlConnection("Data Source= IB-ANBARASU\\SQLSERVER2017; Integrated Security=true;Initial Catalog= designdb; uid=sa; Password=utl@123;"))
            using (SqlConnection con = new SqlConnection("Data Source=WIN-6P1VGEMCAV7\\SQLEXPRESS;Initial Catalog= designdb; uid=nuclyodb;Password=devplus@1234;"))
            using (SqlCommand cmd = new SqlCommand())
                try
                {
                    using (cmd)
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;//StoredProcedure;
                        cmd.CommandText = "Reading";//"Select * From Graphs Where SocietyID = @SocietyID";
                        //cmd.Parameters.Add("@SocietyID", _societyID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable("HouseDetails");
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }

                    if (con != null)
                    {
                        con.Close();
                        con.Dispose();
                    }
                }
        }
    }
}
