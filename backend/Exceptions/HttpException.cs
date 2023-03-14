using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public HttpException(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public static HttpException NotFound(string message = "Id is not found")
        {
            return new HttpException(HttpStatusCode.NotFound, message);
        }
    }
}