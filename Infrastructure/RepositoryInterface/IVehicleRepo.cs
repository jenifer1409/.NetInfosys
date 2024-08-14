using VehicleAPI.Models;

namespace VehicleAPI.Infrastructure.RepositoryInterface
{
    public interface IVehicleRepo
    {
        Task<IEnumerable<VehicleRegistration>> GetAllVehicles();
        Task<VehicleRegistration> GetVehicleById(Guid id);
        Task<VehicleRegistration> AddVehicle(VehicleRegistration vehicleRegistration);

        Task UpdateVehicle(VehicleRegistration vehicleRegistration);

        Task DeleteVehicle(Guid id);
    }
}
