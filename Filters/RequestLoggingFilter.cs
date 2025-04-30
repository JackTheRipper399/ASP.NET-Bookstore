using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BookLibrary.Filters  
{
    public class RequestLoggingFilter : IAsyncActionFilter
    {
        private readonly ILogger<RequestLoggingFilter> _logger;

        public RequestLoggingFilter(ILogger<RequestLoggingFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation("HTTP Request: {Method} {Path}",
                                   context.HttpContext.Request.Method,
                                   context.HttpContext.Request.Path);

            var resultContext = await next();

            _logger.LogInformation("HTTP Response: {StatusCode}",
                                   context.HttpContext.Response.StatusCode);
        }
    }
}
