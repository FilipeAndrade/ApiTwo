using ApiTwo.Controllers;
using ApiTwo.Models;
using ApiTwo.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ApiTwo.Tests.UnitTests.TaxesCalculate
{
    [TestClass]
    public class TaxesCalculateControllerTest
    {
        private Mock<ITaxService> _service;

        private TaxesCommand _command;

        [TestInitialize]
        public void TestInitialize()
        {
            _service = new Mock<ITaxService>();

            _service.Setup(x => x.TaxCalculate(It.IsAny<TaxesCommand>())).Returns(TaxCalculate);

            _command = new TaxesCommand()
            {
                Tempo = 5,
                ValorInicial = 100
            };
        }

        [TestMethod]
        public void PostTaxesCalculate_Success()
        {
            var controller = new TaxesController(_service.Object);

            var response = controller.TaxCalculate(_command);

            var result = response as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("105,10", result.Value);

            _service.Verify(x => x.TaxCalculate(It.IsAny<TaxesCommand>()), Times.Once);
        }

        [TestMethod]
        public void PostTaxesCalculate_Time_Error()
        {
            _command.Tempo = 0;

            var controller = new TaxesController(_service.Object);

            var response = controller.TaxCalculate(_command);

            var result = response as BadRequestObjectResult;

            List<ValidationFailure> errors = (List<ValidationFailure>)result.Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
                        
            _service.Verify(x => x.TaxCalculate(It.IsAny<TaxesCommand>()), Times.Never);
        }

        [TestMethod]
        public void PostTaxesCalculate_ValorInicial_Error()
        {
            _command.ValorInicial = 0;

            var controller = new TaxesController(_service.Object);

            var response = controller.TaxCalculate(_command);

            var result = response as BadRequestObjectResult;

            List<ValidationFailure> errors = (List<ValidationFailure>)result.Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);

            _service.Verify(x => x.TaxCalculate(It.IsAny<TaxesCommand>()), Times.Never);
        }

        #region Mock

        private string TaxCalculate()
        {
            return "105,10";
        }

        #endregion
    }
}
