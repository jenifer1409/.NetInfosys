using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    public abstract class VehicleAbstract
    {
        public string vehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

      


        public abstract void UpdateLocation(string newLocation);


        public abstract void updateSpeed(double newSpeed);
       

        
    }
    public class Trucking : VehicleAbstract
    {
        public double CargoCapacity { get; set; }

        private string currentLocation { get; set; }
        private double speed { get; set; }

        public override void UpdateLocation(string newLocation)
        {
            currentLocation = newLocation;
        }

        public override void updateSpeed(double newSpeed)
        {
            speed = newSpeed;
        }

        public string getStatus()
        {
            return $"Vehicle {vehicleId} : {Make} {Model} is at {currentLocation} moving at {speed} km/h";
        }
    }
}
