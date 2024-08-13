using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class2
{
    public class VehicleRepository : IVehicleRepository
    {
        public readonly Dictionary<dynamic, Vehicle> _vehicle = new Dictionary<dynamic, Vehicle>();
        public void AddVehicle(Vehicle v)
        {
            _vehicle[v.Id] = v;
        }

        public Vehicle GetVehicle(Guid id)
        {
            _vehicle.TryGetValue(id, out var result);
            return result;
        }
    }
}
