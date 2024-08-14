
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Text.RegularExpressions;
using VehicleAPI.Controllers;
using VehicleAPI.CoreServices.ServiceInterface;
using VehicleAPI.Models;

namespace VehicleTest
{
    public class VehicleTest
    {
        private VehicleController _controller;
        private Mock<IVehicleService> _mockService;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IVehicleService>();
            _controller = new VehicleController(_mockService.Object);
        }

        [Test]
        public async Task PostVehicle_Success()
        {
            //Arrange 
            var vehicle = new VehicleRegistration { RegId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"), VehicleId = "abc123", Model = "xx", LastServiceDate = DateTime.Now };
           _mockService.Setup(service => service.AddVehicle(It.IsAny<VehicleRegistration>())).ReturnsAsync(vehicle);
            //Act
            dynamic result = await _controller.PostVehicle(vehicle);

            //Assert

            var actionResult = result as CreatedAtActionResult;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(201, actionResult.StatusCode);
            Assert.AreEqual("GetVehicle",actionResult.ActionName);
            Assert.AreEqual(vehicle, actionResult.Value);

            
        }


        [Test]
        public async Task GetVehicle_Success()
        {
            //Arrange 
            var vehicle = new VehicleRegistration { RegId = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"), VehicleId = "abc123", Model = "xx", LastServiceDate = DateTime.Now };
            Guid id = new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA");
            _mockService.Setup(service => service.GetVehicleById(id)).ReturnsAsync(vehicle);
            //Act
            dynamic result = await _controller.GetById(id);
;            //Assert
            var actionResult = result as OkObjectResult;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(201, actionResult.StatusCode);
            Assert.AreEqual(vehicle, actionResult.Value);
        }
    }
    }

