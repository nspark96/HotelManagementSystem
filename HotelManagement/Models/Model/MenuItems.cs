using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Model
{
    public class MenuItems:Entity
    {
        public string Item_Name { get; set; }
        public string Item_Code { get; set; }
        public CommanType Calling_Name { get; set; }
    }
}