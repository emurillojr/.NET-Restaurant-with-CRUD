using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// Table Class to pull from DB table by ID

namespace SE256demoWEEK1
{
    public class TableCS
    {
        #region Properties
        //match
        public int Tbl_ID { get; set; }
        public int Sect_ID { get; set; }
        public string Tbl_Name { get; set; }
        public string Tbl_Desc { get; set; }
        public int Tbl_Seat_Cnt { get; set; }

        public bool Tbl_Active = false;

        #endregion

        #region Constructors
        public TableCS() { }

        public TableCS(int tbl_id)
        {
            DataTable dt = GetTableByID(tbl_id);  //match

            if (dt.Rows.Count > 0)
            {
                //match
                this.Tbl_ID = (int)dt.Rows[0]["tbl_id"];
                this.Sect_ID = (int)dt.Rows[0]["sect_id"];
                this.Tbl_Name = dt.Rows[0]["tbl_name"].ToString();
                this.Tbl_Desc = dt.Rows[0]["tbl_desc"].ToString();
                this.Tbl_Seat_Cnt = (int)dt.Rows[0]["tbl_seat_cnt"];
                this.Tbl_Active = (bool)dt.Rows[0]["tbl_active"];
            }
        }
        #endregion

        #region Methods/Functions
        private static DataTable GetTableByID(int tbl_id)   //match
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_MurilloConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("[tables_getbyID]", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tbl_id", SqlDbType.Int).Value = tbl_id;

            DataTable dt = new DataTable();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                cn.Close();
            }
            return dt;
        }

        public static bool UpdateTable(TableCS sr)
        {
            bool blnSuccess = false;
            SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["SE256_MurilloConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("tables_update", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(
                  "@tbl_id", SqlDbType.Int).Value = sr.Tbl_ID;
            cmd.Parameters.Add(
                  "@sect_id", SqlDbType.Int).Value = sr.Sect_ID;
            cmd.Parameters.Add(
                  "@tbl_name", SqlDbType.VarChar).Value = sr.Tbl_Name;
            cmd.Parameters.Add(
                "@tbl_desc", SqlDbType.VarChar).Value = sr.Tbl_Desc;
            cmd.Parameters.Add(
                  "@tbl_seat_cnt", SqlDbType.Int).Value = sr.Tbl_Seat_Cnt;
            cmd.Parameters.Add(
                "@tbl_active", SqlDbType.Bit).Value = sr.Tbl_Active;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                blnSuccess = true;
            }
            catch (Exception exc)
            {
                //error -> notify user
                exc.ToString();
                blnSuccess = false;
            }
            finally
            {
                cn.Close();
            }
            return blnSuccess;
        }

        public static bool InsertTable(TableCS sr)
        {
            bool blnSuccess = false;
            SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["SE256_MurilloConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("tables_insert", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(
                  "@sect_id", SqlDbType.Int).Value = sr.Sect_ID;
            cmd.Parameters.Add(
                  "@tbl_name", SqlDbType.VarChar).Value = sr.Tbl_Name;
            cmd.Parameters.Add(
                "@tbl_desc", SqlDbType.VarChar).Value = sr.Tbl_Desc;
            cmd.Parameters.Add(
                  "@tbl_seat_cnt", SqlDbType.Int).Value = sr.Tbl_Seat_Cnt;
            cmd.Parameters.Add(
                "@tbl_active", SqlDbType.Bit).Value = sr.Tbl_Active;

            try
            {
                cn.Open();
                //execute -> stored procedure
                cmd.ExecuteNonQuery();
                blnSuccess = true;
            }
            catch (Exception exc)
            {
                //error -> notify user
                exc.ToString();
                blnSuccess = false;
            }
            finally
            {
                cn.Close();
            }
            return blnSuccess;
        }


        #endregion
    }
}
