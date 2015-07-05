using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Test_Driven.Interface;
using Test_Driven.Model;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void SearchHotelById() {
            //Setup mock data for test
            var mock = this.CreateMockDataTest();
            var productRepository = mock.Object;
            var api = new SearchHotel();
            //Call Service with Interface
            api.AddHotel(productRepository.SearchHotelById(10001));
            api.AddHotel(productRepository.SearchHotelById(10001));
            api.AddHotel(productRepository.SearchHotelById(10002));
            api.AddHotel(productRepository.SearchHotelById(10002));
            api.AddHotel(productRepository.SearchHotelById(10003));
            api.AddHotel(productRepository.SearchHotelById(10003));

            Console.WriteLine("Hotel count : {0}", api.CountHotel);
            Console.WriteLine("Total Price : {0}", api.GetTotalRoomPrice());
            var hotel = api.SearchHotelById(10003);
            Assert.IsTrue(hotel != null, "Not found hotel ");
            if (hotel != null) {
                Assert.IsTrue(hotel.HotelName.Equals("Ramsawintanee Bangkok"));
                Assert.IsTrue(hotel.Room.FirstOrDefault(r=>r.TotalPrice > 9).TotalPrice == 30);
            }
            //Verify logic
            Assert.AreEqual(6, api.CountHotel);
            Assert.AreEqual(120, api.GetTotalRoomPrice());
        }

        [TestMethod]
        public void TestMockMessageProcessor() {
            var mock = new Mock<IMessageProcessor>();
            mock.Setup(processor => processor.Process(It.IsAny<string>())).Returns<string>(msg => string.Format("คุณ: {0}. AI: ไม่เข้าใจข้อความของคุณครับ.", msg));
            mock.Setup(processor => processor.Process("แกเป็นใคร?")).Returns<string>(msg => string.Format("คุณ: {0}. AI: ฉันคือ Message Processor ของคุณไง.", msg));
            mock.Setup(processor => processor.Process("แกทำไรได้บ้างอะ?")).Returns<string>(msg => string.Format("คุณ: {0}. AI: ทำความเข้าใจข้อความของคุณแล้วตอบกลับ เท่าที่คุณโปรแกรมให้ฉันรู้.", msg));

            var mockMessageProcessor = mock.Object;
            Console.WriteLine(mockMessageProcessor.Process("แกเป็นใคร?"));
            Console.WriteLine(mockMessageProcessor.Process("แกทำไรได้บ้างอะ?"));
            Console.WriteLine(mockMessageProcessor.Process("ไหนแกกระโดดซิ"));
        }

        private Mock<IProductRepository> CreateMockDataTest() {
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.SearchHotelById(10001)).Returns(new Hotel { HotelId = 10001, HotelName = "Swiming Hotel Bangkok", Room = new List<Room> { new Room { RoomName = "XXXX1", TotalPrice = 10 } } });
            mock.Setup(m => m.SearchHotelById(10002)).Returns(new Hotel { HotelId = 10002, HotelName = "SaomHotel Sukumvit", Room = new List<Room> { new Room { RoomName = "YYYYY", TotalPrice = 20 } } });
            mock.Setup(m => m.SearchHotelById(10003)).Returns(new Hotel { HotelId = 10003, HotelName = "Ramsawintanee Bangkok", Room = new List<Room> { new Room { RoomName = "ZZZZZZ", TotalPrice = 30 } } });
            return mock;
        }
        //################ Bath file test ###########
        //SET "PATH=C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE"
        //D:
        //cd D:\DEV\DOTNET_DEV\TestProject\Test – Driven Development\UnitTestProject1\bin\Debug
        //del results.trx
        //MSTest /testcontainer:UnitTestProject1.dll /test:UnitTestProject1.UnitTest1.* /resultsfile:results.trx
        //pause
        //##########################################3
    }
}
