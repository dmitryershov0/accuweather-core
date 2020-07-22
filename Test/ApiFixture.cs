using Accuweather.Core;

namespace Accuweather.Test{
    public class ApiFixture: AccuweatherApiCore
    {
        public ApiFixture(string apiKey, string language="en-us")
        :base(apiKey, language)
        {

        }
    }
}