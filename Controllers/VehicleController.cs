using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleAPI.CoreServices.ServiceInterface;
using VehicleAPI.Models;

namespace VehicleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<VehicleRegistration>>> GetVehicles()
        {
            var vehicles = await _vehicleService.GetAllVehicles();
            return Ok(vehicles);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<IEnumerable<VehicleRegistration>>> GetById(Guid id)
        {
            var vehicles = await _vehicleService.GetVehicleById(id);
            return Ok(vehicles);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicles(Guid id)
        {
            await _vehicleService.DeleteVehicle(id);
            return NoContent();
        }

        [HttpPost("addVehicle")]
        public async Task<ActionResult<VehicleRegistration>>PostVehicle(VehicleRegistration vehicleRegistration)
        {
            var newVehicle = await _vehicleService.AddVehicle(vehicleRegistration);
            return Ok(newVehicle);
        }

        [HttpPut]
        public async Task<ActionResult> PutVehicle(VehicleRegistration vehicleRegistration)
        {
            await _vehicleService.UpdateVehicle(vehicleRegistration);
            return NoContent();
        }

    }
}
