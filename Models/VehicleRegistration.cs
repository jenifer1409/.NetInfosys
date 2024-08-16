using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VehicleAPI.Models
{
    public class VehicleRegistration
    {
        [JsonPropertyName("regId")]
        [Key]
        public Guid RegId { get; set; }

        [JsonPropertyName("vehicleId")]
        [Required(ErrorMessage ="Vehicle Id is Required")]
        public string VehicleId { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("lastServiceDate")]
        public DateTime LastServiceDate { get; set; }

    }
}
