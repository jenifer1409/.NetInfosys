using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_class2
{
    public interface IVehicleRepository
    {
        Vehicle GetVehicle(Guid id);
        void AddVehicle(Vehicle v);
    }
}
