using System;

namespace StatsCalculator.Common
{
    /// <summary>
    /// Custom exception wrapper
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="httpStatusCode">Http status code</param>
        /// <param name="productErrorCode">Product code</param>
        public ApiException(string message, int httpStatusCode, int productErrorCode) : base(message)
        {
            {
                HttpStatusCode = httpStatusCode;
                Code = productErrorCode;
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="httpStatusCode">Http status code</param>
        /// <param name="productErrorCode">Product code</param>
        /// <param name="innerException">Inner exception</param>
        public ApiException(string message, int httpStatusCode, int productErrorCode, Exception innerException) : base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
            Code = productErrorCode;
        }


        /// <summary>
        /// The HTTP status code
        /// </summary>
        public int HttpStatusCode { get; set; }

        /// <summary>
        /// The product specific error code
        /// </summary>
        public int Code { get; set; }

    }
}
