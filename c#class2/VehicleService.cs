using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace c_class2
{
    public class VehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IReportGenerator _reportGenerator;

        public VehicleService(IVehicleRepository vehicleRepository, IReportGenerator reportGenerator)
        {
            _vehicleRepository = vehicleRepository;
            _reportGenerator = reportGenerator;
        }
        public void AddVehicle(Guid id, string make, string model, int year)
        {
            var vehicle = new Vehicle(id, make, model, year);
            _vehicleRepository.AddVehicle(vehicle);
        }

        public void PrintVehicleDetails(Guid id)
        {

            var vehicle = _vehicleRepository.GetVehicle(id);
            if (vehicle != null)
            {
                var result = _reportGenerator.GenerateReport(vehicle);
                Console.WriteLine(result);

            }
        }
    }
}
