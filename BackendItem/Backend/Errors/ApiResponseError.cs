namespace Backend.Errors
{
    public class ApiResponseError
    {
        public ApiResponseError(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Loking for Resourcing, it was not found",
                500 => "This is error 500 and cannot assess the internal path ",
                _ => "Consult administrator"
            };
        }
    }
}