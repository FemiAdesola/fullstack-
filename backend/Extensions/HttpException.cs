using System.Net;

namespace Backend.Extensions
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public override string Message { get;  }

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