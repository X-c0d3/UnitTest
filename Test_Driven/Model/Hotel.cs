using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Driven.Interface;

namespace Test_Driven.Model {
    public class Hotel  {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public List<Room> Room { get; set; }
    }
}
