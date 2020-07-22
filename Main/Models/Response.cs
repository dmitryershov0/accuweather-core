using System.Net;

namespace Accuweather.Core.Models{

    /// <summary>
    /// Custom response
    /// </summary>
    public class Response{
        
        /// <summary>
        /// Status code
        /// </summary>
        /// <value></value>
        public HttpStatusCode StatusCode {get;set;}

        /// <summary>
        /// Message
        /// </summary>
        /// <value></value>
        public string Message {get;set;}

        /// <summary>
        /// Response Accuweather Api
        /// </summary>
        /// <value></value>
        public string Data {get;set;}

    }
}