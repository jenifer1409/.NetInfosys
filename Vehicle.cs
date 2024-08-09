using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    public class Vehicle
    {
        public string vehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        private string currentLocation { get; set; }
        private double speed { get; set; }

        public void UpdateLocation(string newLocation)
        {
            currentLocation = newLocation;
        }

        public void updateSpeed(double newSpeed)
        {
            speed = newSpeed;
        }

        public virtual string getStatus()
        {
            return $"Vehicle {vehicleId} : {Make} {Model} is at {currentLocation} moving at {speed} km/h";
        }


    }

    public class Truck : Vehicle
    {
        public double CargoCapacity { get; set; }

        public override string getStatus()
        {
          
            return base.getStatus() + $"Cargo Capacity :{CargoCapacity} tons";
        }
    }
}
