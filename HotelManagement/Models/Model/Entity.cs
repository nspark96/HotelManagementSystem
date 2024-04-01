using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Model
{
    public class Entity
    {
        public int? Id { get; set; }
        public User UserCreated { get; set; }
        public User UserModified { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public CommanType Error { get; set; }
    }
}