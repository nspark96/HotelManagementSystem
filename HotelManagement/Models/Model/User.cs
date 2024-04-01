using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Staff_ID { get; set; }
        public string First_Name { get; set; }
        public string Surname { get; set; }
        public string Staff_Image { get; set; }
        public string Designation { get; set; }
        public string Date_Of_Birth { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Is_Staff { get; set; }
    }
}