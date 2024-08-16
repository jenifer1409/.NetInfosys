using Microsoft.EntityFrameworkCore;
using VehicleAPI.Models;

namespace VehicleAPI.Data
{
    public class VehicleRegistrationContext : DbContext
    {
        public VehicleRegistrationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VehicleRegistration> vehicleRegistrations { get; set; }
    }
}
