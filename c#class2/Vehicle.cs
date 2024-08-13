using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class2
{

    //singleton responsibility
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string  Make { get; set; }

        public string Model { get; set; }
        public int Year { get; set; }

        public Vehicle(Guid id,string make,string model,int year)
        {
            Id = id;
            Make = make;
            Model = model;
            Year = year;
        }
    }
}
