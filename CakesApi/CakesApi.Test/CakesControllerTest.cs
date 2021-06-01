using CakesApi.Business;
using CakesApi.Controllers;
using CakesApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CakesApi.Test
{
    [TestClass]
    public class CakesControllerTest
    {
        private Mock<ICakesService> _cakesService;

        [TestInitialize]
        public void Setup()
        {
            _cakesService = new Mock<ICakesService>();
        }

        [TestMethod]
        public void CheckBadRequestResultIsReturnedForDuplicteCakeName()
        {
            var cakeName = "Cake 1";
            _cakesService.Setup(p => p.Get(cakeName)).Returns(new Cake());
            CakesController CakesController = new CakesController(_cakesService.Object);
            var result = CakesController.Create(new Cake { Name = cakeName });

            var badRequestResult = result as BadRequestObjectResult;
            var problemDetails = badRequestResult.Value as ProblemDetails;
            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual("Cake already exists", problemDetails.Detail);
        }

        [TestMethod]
        public void CheckOkResultIsReturnedForValueCake()
        {
            var cakeName = "Cake 1";
            Cake cake = new Cake { Name = cakeName };
            _cakesService.Setup(p => p.Get(cakeName)).Returns(default(Cake));
            _cakesService.Setup(p => p.Create(cake)).Returns(cake);
            CakesController CakesController = new CakesController(_cakesService.Object);
            var result = CakesController.Create(cake);

            Assert.IsTrue(result is OkObjectResult);
        }
    }
}
