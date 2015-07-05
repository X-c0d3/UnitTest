using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Driven.Model;

namespace Test_Driven.Interface {
    public interface IProductRepository {
        Hotel SearchHotelById(int id);
    }
}
