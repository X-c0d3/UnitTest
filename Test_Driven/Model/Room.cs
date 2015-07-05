using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Driven.Model {
    public class Room {
        public string RoomName { get; set; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
