using System.Net.Http;
using System.Threading.Tasks;
using Accuweather.Core.Models;
using System.Text.Json;

namespace Accuweather.Core.Helpers
{
	/// <summary>
	/// Generate response
	/// </summary>
	public static class ResponseGenerator
	{
		/// <summary>
		/// Returns custom response object.
		/// </summary>
		/// <param name="response">Api respose.</param>
		/// <returns></returns>
		public static async Task<Response> GetResponse(HttpResponseMessage response)
		{
			var res = new Response
			{
				StatusCode = response.StatusCode
			};

			if (!response.IsSuccessStatusCode)
			{
				res.Message = response.ReasonPhrase;
				return res;
			}
			res.Data = await response.Content.ReadAsStringAsync();

			return res;
		}

		/// <summary>
		/// Returns custom response json.
		/// </summary>
		/// <param name="response">Api response.</param>
		/// <returns></returns>
		public static async Task<string> GetResponseJson(HttpResponseMessage response)
		{
			var res = await ResponseGenerator.GetResponse(response);
			return JsonSerializer.Serialize(res);
		}
	}
}