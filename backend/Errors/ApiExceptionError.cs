namespace Backend.Errors
{
    public class ApiExceptionError : ApiResponseError
    {
        public ApiExceptionError(int statusCode, string message = null, string errorDetails = null)
            : base(statusCode, message)
        {
            ErrorDetails = errorDetails;
        }

        public string ErrorDetails { get; set; }
    }
}