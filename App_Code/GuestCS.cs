using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace SE256demoWEEK1
{
    public class GuestCS
    {
        #region Properties
        //match
        public int Guest_ID { get; set; }
        public string Guest_Email { get; set; }
        public string Guest_First { get; set; }
        public string Guest_Last { get; set; }
        public string Guest_Salt { get; set; }
        public string Guest_Pwd { get; set; }
        public string Guest_Phone { get; set; }

        #endregion


        #region Constructors
        public GuestCS()
        {
            this.Guest_Salt = CreateSalt();  // set salt propert value using Salt function
        }

        public GuestCS(int guest_id)
        {
            DataTable dt = GetGuestByID(guest_id);  //match

            if (dt.Rows.Count > 0)
            {
                //match
                this.Guest_ID = (int)dt.Rows[0]["guest_id"];
                this.Guest_Email = dt.Rows[0]["guest_email"].ToString();
                this.Guest_First = dt.Rows[0]["guest_first"].ToString();
                this.Guest_Last = dt.Rows[0]["guest_last"].ToString();
                this.Guest_Salt = dt.Rows[0]["guest_salt"].ToString();
                this.Guest_Pwd = dt.Rows[0]["guest_pwd"].ToString();
                this.Guest_Phone = dt.Rows[0]["guest_phone"].ToString();
            }
        }

        public GuestCS(string guest_email)
        {
            DataTable dt = GuestByEmail(guest_email);

            if (dt.Rows.Count > 0)
            {
                this.Guest_ID = (int)dt.Rows[0]["guest_id"];
                this.Guest_Email = dt.Rows[0]["guest_email"].ToString();
                this.Guest_First = dt.Rows[0]["guest_first"].ToString();
                this.Guest_Last = dt.Rows[0]["guest_last"].ToString();
                this.Guest_Salt = dt.Rows[0]["guest_salt"].ToString();
                this.Guest_Pwd = dt.Rows[0]["guest_pwd"].ToString();
                this.Guest_Phone = dt.Rows[0]["guest_phone"].ToString();
            }
        }

        #endregion

        #region Methods/Functions
        // get guest by ID data table method
        private static DataTable GetGuestByID(int guest_id)   //match
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_MurilloConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("guests_getbyID", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@guest_id", SqlDbType.Int).Value = guest_id;

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

        // create salt function
        public static string CreateSalt()
        {
            // Generate a cryptographic random number using the cryptographic service provider
            byte[] saltBytes = new byte[16];
            // RNGCryptoServiceProvider rng = 
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(saltBytes);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(saltBytes);  // returns string
        }

        // Return Type: string  Name:  CreatePasswordHash method
        public static string CreatePasswordHash(string salt, string password)
        {
            string saltAndPwd = string.Concat(salt, password);
            // Create a new instance of the hash crypto service provider.
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            // Convert the data to hash to an array of Bytes.
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(saltAndPwd);
            // Compute the Hash. This returns an array of Bytes.
            byte[] bytHash = hashAlg.ComputeHash(bytValue);
            // Optionally, represent the hash value as a base64-encoded string, For example, if you need to display the value or transmit it over a network.
            return Convert.ToBase64String(bytHash);  // returns string
        }

        // update guest function
        public static bool UpdateGuest(GuestCS sr)
        {
            bool blnSuccess = false;
            SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["SE256_MurilloConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("guests_update", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
                "@guest_id", SqlDbType.Int).Value = sr.Guest_ID;
            cmd.Parameters.Add(
                "@guest_email", SqlDbType.VarChar).Value = sr.Guest_Email;
            cmd.Parameters.Add(
                "@guest_first", SqlDbType.VarChar).Value = sr.Guest_First;
            cmd.Parameters.Add(
                "@guest_last", SqlDbType.VarChar).Value = sr.Guest_Last;
            cmd.Parameters.Add(
                "@guest_pwd", SqlDbType.VarChar).Value = sr.Guest_Salt;    // salt
            cmd.Parameters.Add(
                "@guest_pwd", SqlDbType.VarChar).Value = sr.Guest_Pwd;   // password
            cmd.Parameters.Add(
               "@guest_phone", SqlDbType.VarChar).Value = sr.Guest_Phone;

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


        // insert guest function
        public static int InsertGuest(GuestCS sr)
        {
            int newID = 0;   //////
            SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["SE256_MurilloConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("guests_insert", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            // Add Parameters -> Stored Procedure
            cmd.Parameters.Add(
                "@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;   // tells sql command catch new_id
            cmd.Parameters.Add(
                "@guest_email", SqlDbType.VarChar).Value = sr.Guest_Email;
            cmd.Parameters.Add(
                "@guest_first", SqlDbType.VarChar).Value = sr.Guest_First;
            cmd.Parameters.Add(
                "@guest_last", SqlDbType.VarChar).Value = sr.Guest_Last;
            cmd.Parameters.Add(
                "@guest_salt", SqlDbType.VarChar).Value = sr.Guest_Salt;    // salt
            cmd.Parameters.Add(
                "@guest_pwd", SqlDbType.VarChar).Value = sr.Guest_Pwd;   // password
            cmd.Parameters.Add(
               "@guest_phone", SqlDbType.VarChar).Value = sr.Guest_Phone;

            // Open database connection -> execute command
            try
            {
                cn.Open();
                //execute -> stored procedure
                cmd.ExecuteNonQuery();
                newID = Convert.ToInt32(cmd.Parameters["@new_id"].Value);   // plug new id into variable
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
            return newID;   // return new id
        }


        public static DataTable GuestByEmail(string email)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["SE256_MurilloConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("guest_getbyEmail", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(
                  "@guest_email", SqlDbType.VarChar).Value = email;
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            catch (Exception exc)
            {
                //error -> notify user
                exc.ToString();

            }
            finally
            {
                cn.Close();
            }
            return dt;
        }
        
        #endregion

    }
}

