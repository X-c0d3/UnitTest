using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Driven.Interface;
using Test_Driven.Model;

namespace Test_Driven {
    class Program {
        static void Main(string[] args) {
            var b = new SearchHotel();
            b.AddHotel(new Hotel {
                HotelId = 100011, HotelName = "Swiming Hotel Bangkok", Room = new List<Room>{
                new Room { Adult = 2, Child = 1, RoomName = "Single delux", TotalPrice = 10 },
                new Room{ Adult = 2, Child = 1, RoomName = "Single delux", TotalPrice = 20 },
            }
            });
            b.AddHotel(new Hotel {
                HotelId = 100011, HotelName = "SaomHotel Sukumvit", Room = new List<Room>{
                new Room{ Adult = 2, Child = 1, RoomName = "Deble delux", TotalPrice = 30 },
                new Room{ Adult = 2, Child = 1, RoomName = "Triple delux", TotalPrice = 40 },
            }
            });
            b.AddHotel(new Hotel {
                HotelId = 100011, HotelName = "Ramsawintanee Bangkok", Room = new List<Room>{
                new Room{ Adult = 2, Child = 1, RoomName = "Suit delux", TotalPrice = 50 },
                new Room{ Adult = 2, Child = 1, RoomName = "Quest delux", TotalPrice = 60 },
            }
            });

            Console.WriteLine("Hotel count : {0}", b.CountHotel);
            Console.WriteLine("Total Price : {0}", b.GetTotalRoomPrice());


            IProductRepository inRepository = b;
            var hotel = inRepository.SearchHotelById(100011);
            if (hotel != null) {
                Console.WriteLine("[+]{0} {1} RoomCount : {2}", hotel.HotelId, hotel.HotelName, hotel.Room.Count);
                foreach (var r in hotel.Room) {
                    Console.WriteLine(" {0} Price : {1} ", r.RoomName, r.TotalPrice);
                }
            }

            Console.ReadLine();
        }
    }
}
