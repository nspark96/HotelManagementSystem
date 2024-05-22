using HotelManagement.Models.Model;
using NCHS_CRM.DataConnection;
using NLF_INTRANET.Comman.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Data
{
    public class UserDL : DataAccessBase
    {
        public User UserLoginCheck(User employee)
        {

            try
            {
                Func<SqlCommand, User> injector = cmd =>
                {
                    var value = Cipher.AESEncrypt(employee.Password);
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = employee.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Cipher.AESEncrypt(employee.Password);
                  
                    //var value = Cipher.AESDecrypt('iiRctL+xWKTP6A8yJRDWLw==');

                    User User = null;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            User = new User
                            {
                                //Id = rdr["ID"].ToString(),
                                Staff_ID = rdr["Staff_ID"].ToString(),
                                Username = rdr["Username"].ToString(),
                                Password = Cipher.AESDecrypt(rdr["Password"].ToString()),
                                First_Name = rdr["First_Name"].ToString(),
                                Surname = rdr["Surname"].ToString(),
                                //ImageName = rdr["Staff_Image"].ToString(),
                                Designation = rdr["Designation"].ToString(),
                                //DefaultPassword = Cipher.AESDecrypt(rdr["UserDefaultPassword"].ToString()),
                                //Branch = rdr["Branch"].ToString(),
                            };
                        }
                    }
                    return User;
                };
                return Data.SqlSpExecute("sp_UserLoginCheck", injector);
            }
            catch (Exception e)
            {
                var x = e;
                User User = null;
                User = new User
                {

                    Staff_ID = x.ToString(),
                    //Branch = rdr["Branch"].ToString(),
                };
                return User;
            }
        }

    }
}