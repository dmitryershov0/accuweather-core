using System.Linq;
using System.Web;
namespace Accuweather.Core.Helpers{

    public static class UrlEncodeHelper
    {
        public static string UrlEncodeObject(object obj)
		{
			var props = obj.GetType().GetProperties()
				.Where(p => p.GetValue(obj, null) != null)
				.Select(p => $"{p.Name}={HttpUtility.UrlEncode(p.GetValue(obj, null).ToString())}");

			return string.Join("&", props.ToArray()); ;
		}
		public static string UrlEncode(object obj, string url)
		{
			return $"{url}{UrlEncodeObject(obj)}";
		}
    }
}