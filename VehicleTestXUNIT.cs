using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using VehicleAPI.Controllers;
using VehicleAPI.CoreServices.ServiceInterface;
using VehicleAPI.Infrastructure.RepositoryInterface;
using VehicleAPI.Models;

namespace XUnitVehicleTest
{
    public class VehicleTestXUNIT

    {

        private VehicleController _controller;
        private Mock<IVehicleService> _mockService;
        private Mock<IVehicleRepo> _mockRepo;

          public VehicleTestXUNIT()
        {
            _mockService = new Mock<IVehicleService>();
            _mockRepo = new Mock<IVehicleRepo>();
            _controller = new VehicleController(_mockService.Object);
        }

        [Fact]
        public async Task GetVehicle_Success()
        {
            //Arrange 
            var registerId = Guid.NewGuid();

            var vehicle = new VehicleRegistration { RegId = registerId, VehicleId = "abc123", Model = "xx", LastServiceDate = DateTime.Now };

            _mockService.Setup(service => service.GetVehicleById(registerId)).ReturnsAsync(vehicle);

            _mockRepo.Setup(repo => repo.GetVehicleById(registerId)).ReturnsAsync(vehicle);

            //Act
            var result = await _controller.GetById(registerId);
            //Assert
            var actionResult = Assert.IsType<ActionResult<VehicleRegistration>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedVehicle = Assert.IsType<VehicleRegistration>(okObjectResult.Value);

            Assert.Equal(registerId, returnedVehicle.RegId);

        }


        [Fact]
        public async Task DeleteVehicleTest__Success()
        {
            var registerId = Guid.NewGuid();

            _mockService.Setup(service => service.DeleteVehicle(registerId));

            _mockRepo.Setup(repo => repo.DeleteVehicle(registerId));

            //Act
            var result = await _controller.DeleteVehicles(registerId);

            //Assert

            //204 : success and it returns no content

            // 404 : error and not found

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateVehicleTest__Success()
        {
            var registerId = Guid.NewGuid();
            var vehicle = new VehicleRegistration { RegId = registerId, VehicleId = "abc123", Model = "xx", LastServiceDate = DateTime.Now };

            _mockService.Setup(service => service.UpdateVehicle(vehicle));

            _mockRepo.Setup(repo => repo.UpdateVehicle(vehicle));

            //Act
            var result = await _controller.PutVehicle(vehicle);

            //Assert

            var noContent = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContent.StatusCode);
        }
    }
}