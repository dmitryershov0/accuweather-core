using NUnit.Framework;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Net;
namespace Accuweather.Test
{
	public class AccuweatherApiCoreTests
	{
		private ApiFixture _fixture;

		public AccuweatherApiCoreTests()
		{
			_fixture = new ApiFixture("apikey");
		}
        private void RespsonseStatusCode(string jsonResult, HttpStatusCode code)
        {
            var result = JsonSerializer.Deserialize<Accuweather.Core.Models.Response>(jsonResult);
            Assert.AreEqual(result.StatusCode, code);
        }
        private static object[] SendGetRequestParams = {
            new object [] {"http://dataservice.accuweather.com/locations/v1/adminareas/RU", HttpStatusCode.Unauthorized},
            new object [] {"http://jsonplaceholder.typicode.com/posts", HttpStatusCode.OK},
        };

		[Test, TestCaseSource("SendGetRequestParams")]
		public async Task SendGetRequest(string url, HttpStatusCode code)
		{
			var jsonResult = await _fixture.SendGetRequest(url);
			RespsonseStatusCode(jsonResult, code);
		}

		[Test]
		public async Task SendPostRequest()
		{
			var stringPayload = JsonSerializer.Serialize(new
			{
				title = "foo",
				body = "bar",
				userId = 1
			});
			var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
			var url = "http://jsonplaceholder.typicode.com/posts";
			var jsonResult = await _fixture.SendPostRequest(url, httpContent);
			RespsonseStatusCode(jsonResult, HttpStatusCode.OK);
		}

	}
}