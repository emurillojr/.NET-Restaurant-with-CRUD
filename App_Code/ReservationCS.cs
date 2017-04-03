using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

// Reservation Class to pull from DB reversation by ID

namespace SE256demoWEEK1
{
    public class ReservationCS
    {
        #region Properties
        //match
        public int Res_ID { get; set; }
        public int Guest_ID { get; set; }
        public int Tbl_ID { get; set; }
        public int User_ID { get; set; }
        public string Res_Date { get; set; }
        public string Res_Time { get; set; }
        public int Res_Guest_Cnt { get; set; }
        public string Res_Spec_Req { get; set; }
        #endregion

        #region Constructors
        public ReservationCS() { }
        public ReservationCS(int res_id)
        {
            DataTable dt = GetResByID(res_id);  //match

            if (dt.Rows.Count > 0)
            {
                //match
                this.Res_ID = (int)dt.Rows[0]["res_id"];
                this.Guest_ID = (int)dt.Rows[0]["guest_id"];
                this.Tbl_ID = (int)dt.Rows[0]["tbl_id"];
                this.User_ID = (int)dt.Rows[0]["user_id"];
                this.Res_Date = Convert.ToDateTime(dt.Rows[0]["res_date"]).ToString("yyyy-MM-dd");  //"MM-dd-yyyy"
                this.Res_Time = dt.Rows[0]["res_time"].ToString();
                this.Res_Guest_Cnt = (int)dt.Rows[0]["res_guest_cnt"];
                this.Res_Spec_Req = dt.Rows[0]["res_spec_req"].ToString();

            }
        }
        #endregion

        #region Methods/Functions
        private static DataTable GetResByID(int res_id)   //match
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_MurilloConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("reservations_getbyID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@res_id", SqlDbType.Int).Value = res_id;

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

        public static bool UpdateReservation(ReservationCS sr)
        {
            //declare return variable
            bool blnSuccess = false;
            //connection object -> ConfigurationManager namespace
            //access web.config setting -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_MurilloConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("reservations_update", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
                  "@res_id", SqlDbType.Int).Value = sr.Res_ID;
            cmd.Parameters.Add(
                  "@guest_id", SqlDbType.Int).Value = sr.Guest_ID;
            cmd.Parameters.Add(
                  "@tbl_id", SqlDbType.Int).Value = sr.Tbl_ID;
            cmd.Parameters.Add(
                  "@user_id", SqlDbType.Int).Value = sr.User_ID;
            cmd.Parameters.Add(
                  "@res_date", SqlDbType.Date).Value = sr.Res_Date;
            cmd.Parameters.Add(
                "@res_time", SqlDbType.Time).Value = sr.Res_Time;
            cmd.Parameters.Add(
                 "@res_guest_cnt", SqlDbType.Int).Value = sr.Res_Guest_Cnt;
            cmd.Parameters.Add(
                "@res_spec_req", SqlDbType.VarChar).Value = sr.Res_Spec_Req;

            // Open database connection -> execute command
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


        //insert function here
        public static int InsertReservation(ReservationCS sr)
        {
            //declare return variable
            int new_id = 0;
            //connection object -> ConfigurationManager namespace
            //access to web.config -> connection strings & key values
            SqlConnection cn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SE256_MurilloConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("reservations_insert", cn);
            // Mark the Command -> Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(
                "@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;
           // cmd.Parameters.Add(
            
            cmd.Parameters.Add(
                  "@guest_id", SqlDbType.Int).Value = sr.Guest_ID;
            cmd.Parameters.Add(
                  "@tbl_id", SqlDbType.Int).Value = sr.Tbl_ID;
            cmd.Parameters.Add(
                  "@user_id", SqlDbType.Int).Value = sr.User_ID;
            cmd.Parameters.Add(
                  "@res_date", SqlDbType.Date).Value = sr.Res_Date;
            cmd.Parameters.Add(
                "@res_time", SqlDbType.Time).Value = sr.Res_Time;
            cmd.Parameters.Add(
                 "@res_guest_cnt", SqlDbType.Int).Value = sr.Res_Guest_Cnt;
            cmd.Parameters.Add(
                "@res_spec_req", SqlDbType.VarChar).Value = sr.Res_Spec_Req;


            // Open database connection -> execute command
            try
            {
                cn.Open();
                //execute -> stored procedure
                cmd.ExecuteNonQuery();
                new_id = Convert.ToInt32(cmd.Parameters["@new_id"].Value);

            }
            catch (Exception exc)
            {
                //error -> notify user
                exc.ToString();
                // blnSuccess = false;
            }
            finally
            {
                cn.Close();
            }
            return new_id;
        }



        public static int GetAvailableTable(string date, string time, int guestCount)
        {
            int tblID = 0;   //////

            SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["SE256_MurilloConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("tables_getAvailable", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
                "@res_date", SqlDbType.Date).Value = date;
            cmd.Parameters.Add(
                "@res_time", SqlDbType.Time).Value = time;
            cmd.Parameters.Add(
                "@res_guest_cnt", SqlDbType.Int).Value = guestCount;

            // Open database connection -> execute command
            try
            {
                cn.Open();
                //execute -> stored procedure
                //cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();   // data reader with results
                dr.Read();
                tblID = Convert.ToInt32(dr["tbl_id"]);

                //newID = Convert.ToInt32(cmd.Parameters["@new_id"].Value);   // plug new id into variable
            }
            catch (Exception exc)
            {
                //error -> notify user
                exc.ToString();
                //blnSuccess = false;
            }
            finally
            {
                cn.Close();
            }
            return tblID;   // return new id
        }
        
        #endregion

    }
}
