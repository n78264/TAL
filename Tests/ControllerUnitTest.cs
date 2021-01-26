using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PremiumCalculator.Controllers;
using PremiumCalculator.Entities;
using PremiumCalculator.Models;
using PremiumCalculator.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace API.Tests
{
    [TestClass]
    public class ControllerUnitTest
    {
        ResourceController _controller;
        IRepository _service;

        [TestInitialize()]
        public void Initialize()
        {
            _service = new FakeRepository();
            _controller = new ResourceController(_service);
        }

        [TestMethod]
        public void Get_WhenCalled_ReturnsAllOccupations()
        {
            var result = _controller.GetOccupations();
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            var responseList = okResult.Value as IEnumerable<Occupation>;
            Assert.AreEqual(6, responseList.Count());
        }

        [TestMethod]
        public void Get_WhenCalled_ReturnsOneOccupation()
        {
            var result = _controller.GetOccupationById(10002);
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            var responseObject = okResult.Value as Occupation;
            Assert.AreEqual(10002, responseObject.Id);
            Assert.AreEqual("Doctor", responseObject.Name);
        }

        [TestMethod]
        public void Get_WhenCalled_ReturnsAllRatings()
        {
            var result = _controller.GetRatings();
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            var responseList = okResult.Value as IEnumerable<Rating>;
            Assert.AreEqual(4, responseList.Count());
        }

        [TestMethod]
        public void Get_WhenCalled_ReturnsOneRating()
        {
            var result = _controller.GetRatingById(20002);
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            var responseObject = okResult.Value as Rating;
            Assert.AreEqual(1.25, responseObject.Factor);
            Assert.AreEqual("White Collar", responseObject.Name);
        }

        [TestMethod]
        public void Get_WhenCalled_ReturnsFactor()
        {
            var result = _controller.GetRatingFactorById(10003);
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            var responseObject = okResult.Value as OccupationRatingViewModel;
            Assert.AreEqual(1.25, responseObject.Factor);
        }
    }
}
