using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;  // added for lab 5
using System.Data.SqlClient; // added for lab 5  needed for sql connection
using System.Data; // added for lab 5   needed for datatable
using System.Configuration;  // added for lab 5
using System.Security.Cryptography;   // added for lab 5


namespace SE256demoWEEK1
{
    public class AppUser
    {

        #region Properties
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HashedPassword { get; set; }
        public bool ValidLogin { get; set; }
        #endregion

        // default constructor
        #region Constructors
        public AppUser()
        {
            this.Salt = CreateSalt();  // set salt propert value using Salt function
        }

        //overloaded constructor 
        public AppUser(string email)   // define one input parameter of type String named Email 
        {
            DataTable dt = GetUser(email);    // invoke the GetUser(string email) function to return a DataTable object

            if (dt.Rows.Count > 0)
            {
                this.UserId = (int)dt.Rows[0]["user_id"];
                this.Email = dt.Rows[0]["user_email"].ToString();
                this.Salt = dt.Rows[0]["user_salt"].ToString();
                this.FirstName = dt.Rows[0]["user_first"].ToString();
                this.LastName = dt.Rows[0]["user_last"].ToString();
                this.HashedPassword = dt.Rows[0]["user_pwd"].ToString();
                this.ValidLogin = false;
            }
        }
        #endregion



        #region Methods
        // Return Type: string  Name: CreateSalt method
        private static string CreateSalt()
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
        private static string CreatePasswordHash(string salt, string password)
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

        // Return Type: DataTable Name: GetUser method
        private static DataTable GetUser(string email)
        {
            //create sql connection object // check webconfig for what to add in " " 
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SE256_MurilloConnectionString"].ConnectionString);
            // ****  invoke an ADO.NET stored procedure call to your SQL Server database instance.
            //create sql command  // " " = stored procedure name 
            SqlCommand cmd = new SqlCommand("users_getbyEmail", cn);
            cmd.CommandType = CommandType.StoredProcedure;  // Mark the Command as a Stored Procedure
            //updated variable name  - changed to pUserEmail    " " = check inside created stored procedure for whatever @value is
            SqlParameter pUserEmail = new SqlParameter("@user_email", SqlDbType.VarChar, 50);
            pUserEmail.Value = email;
            cmd.Parameters.Add(pUserEmail);
            //instantiate return type
            DataTable dt = new DataTable();

            // Open the database connection and execute the command
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                //process errors here
            }
            finally
            {
                cn.Close();
            }

            // *** return the row associated with the email parameter passed in and will be used to provide data to the overloaded constructor.
            return dt;   // Return the dataset 
        }


        // Return Type: AppUser Name: Login method
        public static AppUser Login(string email, string password)
        {
            //Step 1: Instantiate an AppUser object using the overloaded constructor and email parameter passed in.
            AppUser au = new AppUser(email);

            //Step 2: Using the Salt property value of the AppUser object from Step 1 , the au, and the password parameter sent to the function
            //create a string variable and set its value to the CreatePasswordHash() function’s return value.
            string testPassword = CreatePasswordHash(au.Salt, password);

            //Step 3: Using conditional logic, compare the AppUser’s HashedPassword property value to the string variable value created in Step 2
            //If they match, set the ValidLogin property value to “True”, if they dont match, set the ValidLogin property value to “False”.
            if (au.HashedPassword == testPassword)
            {
                au.ValidLogin = true;  //Setting the AppUser’s ValidLogin property to true because they match
            }
            else
            {
                au.ValidLogin = false;  //Setting the AppUser’s ValidLogin property to false since they dso not match.
            }
            //Step 4:  Return the AppUser object since this is the functions return value.
            return au;
        }
        #endregion
    }
}