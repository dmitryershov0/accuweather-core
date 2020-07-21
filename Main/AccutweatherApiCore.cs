using Accuweather.Core.Helpers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Accuweather.Core
{
	public abstract class AccuweatherApiCore
	{
		protected readonly string _apiKey;

		protected readonly string _language = "en-us";

		private readonly HttpClientHandler _handler = new HttpClientHandler()
		{
			AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
		};
		
		public AccuweatherApiCore(string apiKey, string language = "")
		{
			_apiKey = apiKey;
			if (!string.IsNullOrEmpty(language))
				_language = language;
		}

		public async Task<string> SendGetRequest(string url)
		{
			using (var client = new HttpClient(_handler))
			{
				var response = await client.GetAsync(url);
				return await ResponseGenerator.GetResponseJson(response);
			}
		}
		public async Task<string> SendPostRequest(string url, HttpContent content)
		{
			using (var client = new HttpClient(_handler))
			{
				var response = await client.PostAsync(url, content);
				return await ResponseGenerator.GetResponseJson(response);
			}
		}
		
	}
}
