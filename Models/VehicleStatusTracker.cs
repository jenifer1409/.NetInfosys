using System.ComponentModel.DataAnnotations;

namespace VehicleWebApplication.Models
{
    public class VehicleStatusTracker
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public int Speed { get; set; }

    }
}
