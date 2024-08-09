using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    public interface Car
    {
        void Speed(double newSpeed);
        void Location(string newLocation);
    }

    public interface CarSpecification
    {
        void Make();
        void Model();
    }
    internal class VehicleInterface : Car, CarSpecification
    {
        public string currentLocation { get; set; }
        public double speed { get; set; }


        public void Location(string newLocation)
        {
            currentLocation = newLocation;
            Console.WriteLine(currentLocation);
        }

        public void Make()
        {
            Console.WriteLine("ford");
        }

        public void Model()
        {
            Console.WriteLine("ford");
        }

        public void Speed(double newSpeed)
        {
            speed = newSpeed;
            Console.WriteLine(speed);
        }
    }

        
    
}
