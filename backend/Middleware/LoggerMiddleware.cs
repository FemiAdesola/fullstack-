namespace Backend.Middleware
{
    public class LoggerMiddleware : IMiddleware
    {
        private readonly ILogger<LoggerMiddleware> _logger;
        public LoggerMiddleware(ILogger<LoggerMiddleware> logger)
        {
            _logger = logger;

        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation($"Request url: {context.Request.Protocol} {context.Request.Path}");
            await next(context);
        }
    }
}