using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Model
{
    public class RoomReservation
    {
        public int ID { get; set; }
        public Room Room { get; set; }
        public Customer Customer { get; set; }
        public string Date { get; set; }
        public Status Status { get; set; }
        public string Availability { get; set; }
    }
}