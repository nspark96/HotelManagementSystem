using HotelManagement.Models.Data;
using HotelManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Business
{
    public class UserBL
    {
        UserDL UDL = new UserDL();
        public User UserLoginCheck(User user)
        {
            return UDL.UserLoginCheck(user);
        }
    }
}