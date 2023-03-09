namespace Exceptions;

public abstract class HttpException : Exception
{
    public abstract int StatusCode { get; set; }

    public HttpException()
    {

    }
    // public HttpException(string message) : base(message) { }

    public HttpException(string message, int statusCode) : base(message) => StatusCode = statusCode;
}
