using Microsoft.AspNetCore.Mvc.Testing;
using api;
namespace Integration_tests.Clients
{
    internal class ClientsApi
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
        }

        [Test]
        public async Task GetClientsWithLinqTestSuccess()
        {
            //Arrange
            int page = 1;
            int pageSize = 10;

            //Act
            var result = await _client.GetAsync($"clients/linq?page={page}&pageSize={pageSize}");
            //Assert
            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.IsNotNull(result.Content);
        }

        [Test]
        public async Task GetClientsWithStoreProcedureTestSuccess()
        {
            //Arrange
            int page = 1;
            int pageSize = 10;

            //Act
            var result = await _client.GetAsync($"clients/store-procedure?page={page}&pageSize={pageSize}");
            //Assert
            Assert.IsTrue(result.IsSuccessStatusCode);
            Assert.IsNotNull(result.Content);
        }

        [TearDown]
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
