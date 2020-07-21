using NUnit.Framework;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AccuweatherCore.Test
{
    public class AccuweatherApiCoreTests
    {
        private ApiFixture _fixture;

        [SetUp]
        public void Init()
        {
            _fixture = new ApiFixture("apikey");
        }

        [Test]
        public async Task SendGetRequest()
        {
            var url = "http://jsonplaceholder.typicode.com/posts";
            var result = await _fixture.SendGetRequest(url);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task SendPostRequest()
        {
            var stringPayload = JsonSerializer.Serialize(new {
                title ="foo",
                body ="bar",
                userId = 1
            });
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var url = "http://jsonplaceholder.typicode.com/posts";
            var result = await _fixture.SendPostRequest(url, httpContent);
            Assert.IsNotEmpty(result);
        }

    }
}