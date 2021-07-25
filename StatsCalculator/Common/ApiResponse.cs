using Newtonsoft.Json;
using System.ComponentModel;

namespace StatsCalculator.Common
{
    /// <summary>
    /// Provides common Api response for methods in case or errors/exceptions
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpStatusCode">The http status code that is sent back as response</param>
        /// <param name="code">The product error code</param>
        /// <param name="message">The message</param>
        /// <param name="developerMessage">The developer friendly message in case developer needed stack trace</param>
        public ApiResponse(int httpStatusCode, int code, string message, string developerMessage)
        {
            Message = message;
            HttpStatus = httpStatusCode;
            Code = code;
            DeveloperMessage = developerMessage;
        }

        /// <summary>
        /// Constructor used only to send back the http status code
        /// </summary>
        /// <param name="httpStatusCode">The http status code</param>
        public ApiResponse(int httpStatusCode)
        {
            HttpStatus = httpStatusCode;
        }

        /// <summary>
        /// Message describing the error
        /// </summary>
        /// 
        [DefaultValue("No message")]
        [JsonProperty("message", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string Message { get; set; }


        /// <summary>
        /// The HTTP status of the error 
        /// </summary>
        [JsonProperty("status")]
        public int HttpStatus { get; set; }

        /// <summary>
        /// Application specific error code
        /// </summary>
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public int? Code { get; set; }

        /// <summary>
        /// The developer message for the api error/exception
        /// </summary>

        [DefaultValue("No developer message")]
        [JsonProperty("message", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string DeveloperMessage { get; set; }

    }
}
