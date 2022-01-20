using MESDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MES_WEB_API.Models
{
    public class UserDAC : IDisposable
    {
        SqlConnection conn;
        public UserDAC()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }

        public void Dispose()
        {
            conn.Close();
        }


        public UserVO CheckUser(UserVO user)
        {

            string sql = "select Email,Password,IsAdmin,FirstName,LastName from Enrollment where Email=@Email and Password=@Password";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                conn.Open();
                List<UserVO> list = Helper.DataReaderMapToList<UserVO>(cmd.ExecuteReader());
                conn.Close();

                if (list != null && list.Count > 0)
                    return list[0];
                else
                    return null;
                
            }
        }

        public int CheckID(string id)
        {
            string sql = "select COUNT(Email) from Enrollment where Email =@Email";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Email", id);
                cmd.Connection.Open();


                return Convert.ToInt32(cmd.ExecuteScalar()) ;
                

            }
        }

        public bool CreateUser(UserVO user)
        {
            string sql = @"insert into Enrollment (FirstName, LastName, Password, Email)
values(@FirstName, @LastName, @Password, @Email)";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email", user.Email);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public List<UserVO> GetUserList()
        {
            string sql = $@"select ID, FirstName, LastName, Password, Email,IsAdmin from Enrollment";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    return Helper.DataReaderMapToList<UserVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public bool DeleteUser(string ID)
        {
            string sql = @"Delete from Enrollment where ID = @ID ";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Connection.Open();

                    cmd.Parameters.AddWithValue("@ID", ID);

                    int iRowAffect = cmd.ExecuteNonQuery();

                    return (iRowAffect > 0);
                }
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public bool UpdateUser(UserVO user)
        {
            string sql = "Update Enrollment set FirstName=@FirstName, LastName=@LastName, Password=@Password, Email=@Email,IsAdmin=@IsAdmin where ID=@ID";

            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }
}