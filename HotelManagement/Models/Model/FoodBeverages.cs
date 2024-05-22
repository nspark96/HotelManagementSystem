using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Model
{
    public class FoodBeverages
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Availability { get; set; }
        public string Price { get; set; }
        public Status Type { get; set; }
    }
}