using Microsoft.EntityFrameworkCore;
using VehicleAPI.Data;
using VehicleAPI.Infrastructure.RepositoryInterface;
using VehicleAPI.Models;

namespace VehicleAPI.Infrastructure.DataRepository
{
    public class VehicleRepo : IVehicleRepo
    {
        private readonly VehicleRegistrationContext _context;
        public VehicleRepo(VehicleRegistrationContext context)
        {
            _context = context;
        }

        public async Task<VehicleRegistration> AddVehicle(VehicleRegistration vehicleRegistration)
        {
            _context.vehicleRegistrations.Add(vehicleRegistration);
            await _context.SaveChangesAsync();
            return vehicleRegistration;
        }

        public async Task DeleteVehicle(Guid id)
        {
            var vid = await _context.vehicleRegistrations.FindAsync(id);
            if (vid!=null)
            {
                _context.vehicleRegistrations.Remove(vid);
                await _context.SaveChangesAsync();
            }         
        }

        public async Task<IEnumerable<VehicleRegistration>> GetAllVehicles()
        {
            var vehicles = await _context.vehicleRegistrations.ToListAsync();
            return vehicles;
        }

        public async Task<VehicleRegistration> GetVehicleById(Guid id)
        {
            var vehicles = await _context.vehicleRegistrations.FindAsync(id);
            return vehicles;
        }

        public async Task UpdateVehicle(VehicleRegistration vehicleRegistration)
        {
       
                _context.Entry(vehicleRegistration).State = EntityState.Modified;
               await _context.SaveChangesAsync();
           
        }
    }
}
