using Microsoft.EntityFrameworkCore;

namespace VehicleWebApplication.Models
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VehicleStatusTracker> vehicleStatusTrackers { get; set; }
    }
}
