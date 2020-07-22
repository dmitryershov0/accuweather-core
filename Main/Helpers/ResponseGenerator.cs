using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Accuweather.Core.Models;
using System.Text.Json;

namespace Accuweather.Core.Helpers
{
    public static class ResponseGenerator
    {
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

        public static async Task<string> GetResponseJson(HttpResponseMessage response)
        {
           var res = await ResponseGenerator.GetResponse(response);
           return JsonSerializer.Serialize(res);
        }
    }
}