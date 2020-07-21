using System.Net;

namespace Accuweather.Core.Models{
    public class Response{
        public HttpStatusCode StatusCode {get;set;}
        public string Message {get;set;}
        public string Data {get;set;}

    }
}