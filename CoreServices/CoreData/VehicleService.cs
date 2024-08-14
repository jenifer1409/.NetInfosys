using VehicleAPI.CoreServices.ServiceInterface;
using VehicleAPI.Infrastructure.RepositoryInterface;
using VehicleAPI.Models;

namespace VehicleAPI.CoreServices.CoreData
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepo _vehicleRepo;
        public VehicleService(IVehicleRepo vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        public async Task<VehicleRegistration> AddVehicle(VehicleRegistration vehicleRegistration)
        {
            return await _vehicleRepo.AddVehicle(vehicleRegistration);
        }

        public async Task DeleteVehicle(Guid id)
        {
            await _vehicleRepo.DeleteVehicle(id);
        }

        public async Task<IEnumerable<VehicleRegistration>> GetAllVehicles()
        {
            return await _vehicleRepo.GetAllVehicles();
        }

        public async Task<VehicleRegistration> GetVehicleById(Guid id)
        {
            return await _vehicleRepo.GetVehicleById(id);
        }

        public async Task UpdateVehicle(VehicleRegistration vehicleRegistration)
        {
            await _vehicleRepo.UpdateVehicle(vehicleRegistration);
        }
    }
}
