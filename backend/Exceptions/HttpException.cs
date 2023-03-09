namespace Exceptions;

public abstract class HttpException : Exception
{
    public abstract int StatusCode { get; }

    public HttpException()
    {

    }
    public HttpException(string message) : base(message) { }
}
