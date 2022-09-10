using ApiTwo.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiTwo.Tests.UnitTests.SourceCode
{
    [TestClass]
    public class SourceCodeControllerTest
    {
        [TestMethod]
        public void GetSourceCodeUrl_Success()
        {
            var controller = new SourceCodeController();

            var response = controller.Get();

            var result = response as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("https://github.com/FilipeAndrade/ApiTwo", result.Value);
        }
    }
}
