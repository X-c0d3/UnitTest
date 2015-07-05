using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Driven.Interface;

namespace Test_Driven.Model {
    public class SearchHotel : IProductRepository {
        List<Hotel> _myBasket;
        public SearchHotel() {
            _myBasket = new List<Hotel>();
        }

        public void AddHotel(Hotel p) {
            _myBasket.Add(p);
        }

        public int CountHotel { get { return _myBasket.Count; } }

        public decimal GetTotalRoomPrice() {
            return _myBasket.Sum(hotel => (from p in hotel.Room select p.TotalPrice).Sum());
        }

        public Hotel SearchHotelById(int hotelid) {
            return _myBasket.FirstOrDefault(h => h.HotelId == hotelid);
        }
    }
}
