using VehicleAPI.Models;

namespace VehicleAPI.CoreServices.ServiceInterface
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleRegistration>> GetAllVehicles();
        Task<VehicleRegistration> GetVehicleById(Guid id);
        Task<VehicleRegistration> AddVehicle(VehicleRegistration vehicleRegistration);
        Task UpdateVehicle(VehicleRegistration vehicleRegistration);
        Task DeleteVehicle(Guid id);
    }
}
