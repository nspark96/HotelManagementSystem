using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Model
{
    public class FoodOrders
    {
        public int ID { get; set; }
        public FoodBeverages FoodBeverages { get; set; }
        public Customer Customer { get; set; }
        public string Date { get; set; }
        public string Availability { get; set; }
    }
}