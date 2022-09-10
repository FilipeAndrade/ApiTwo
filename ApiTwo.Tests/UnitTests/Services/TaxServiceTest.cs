using ApiTwo.Models;
using ApiTwo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTwo.Tests.UnitTests.Services
{
    [TestClass]
    public class TaxServiceTest
    {
        Mock<IHttpClientService> _httpClientServie;

        private TaxesCommand _command;
        private ITaxService _service;
        private HttpRequestMessage _response;
        private Mock<HttpClient> _httpClient;

        [TestInitialize]
        public void TestInitialize()
        {
            _httpClientServie = new Mock<IHttpClientService>();

            _httpClient = new Mock<HttpClient>();

            _response = new HttpRequestMessage();

            _command = new TaxesCommand()
            {
                Tempo = 5,
                ValorInicial = 100
            };

            _httpClientServie.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(GetAsync);

            _httpClientServie.Setup(x => x.CreateClient()).Returns(CreateClient);

            _service = new TaxService(_httpClientServie.Object);
        }

        [TestMethod]
        public void TaxesCalculate_Success()
        {
            var result = _service.TaxCalculate(_command);

            Assert.IsNotNull(result);
            Assert.AreEqual("105,10", result);
        }

        [TestMethod]
        public void PostTaxesCalculate_ApiOne_Timeout_Error()
        {
            _httpClientServie.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(GetAsyncError);

            var result = _service.TaxCalculate(_command);

            Assert.IsNotNull(result);
            Assert.AreEqual("Não foi possível calcular os juros compostos", result);
        }

        #region Mock

        private async Task<HttpResponseMessage> GetAsync()
        {
            return await Task.FromResult(new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent("0,01") });
        }

        private async Task<HttpResponseMessage> GetAsyncError()
        {
            return await Task.FromResult(new HttpResponseMessage() { StatusCode = HttpStatusCode.RequestTimeout, Content = new StringContent("0") });
        }

        private HttpClient CreateClient()
        {
            return _httpClient.Object;
        }

        #endregion
    }
}
