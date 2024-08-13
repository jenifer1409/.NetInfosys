using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class2
{
    public class VehicleConstruct
    {
        public int VehicleId { get; set; }
        public  string License { get; set; }

        public string  Location { get; set; }
        public int Speed { get; set; }

          public VehicleConstruct()
        {
            VehicleId = 101;
            License = "mx123";
            Location = "NYC";
            Speed = 100;
                
        }

        public VehicleConstruct(int id,string license,string location,int speed)
        {
            VehicleId = id;
            License = license;
            Location = location;
            Speed = speed;
        }

        public VehicleConstruct(VehicleConstruct vehicleConstruct)
        {
            VehicleId = vehicleConstruct.VehicleId;
            License = vehicleConstruct.License;
            Location = vehicleConstruct.Location;
            Speed = vehicleConstruct.Speed;
        }

        ~VehicleConstruct()
        {
            Console.WriteLine("object destroyed");
        }
        public void GetVehicleStatus()
        {
            Console.WriteLine($"{VehicleId} with the License {License} is at {Location} with the speed of {Speed}");
        }



    }
}


