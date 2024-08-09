using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    internal class VehicleOverload
    {
        public void updateVehicle(string location)
        {
            Console.WriteLine($"{location}");
        }

        public void updateVehicle(string location,string make)
        {
            Console.WriteLine($"{location} and make is {make}");
        }
        public void updateVehicle(string location,double speed)
        {
            Console.WriteLine($"{location} and speed is {speed}");
        }
        public int updateVehicle(int speed)
        {
            return speed;
        }
        public void updateVehicle(string make,string model,string location ,double speed)
        {
            Console.WriteLine($"Vehicle with the {make}{model} is in the location :{location} with the speed {speed}");
        }
    }
}
