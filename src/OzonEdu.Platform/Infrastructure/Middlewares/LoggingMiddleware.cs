using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OzonEdu.Platform.Infrastructure.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogRequest(context);
            await _next(context);
            LogResponse(context);
        }

        private void LogRequest(HttpContext context)
        {
            if (context.Request.ContentType == "application/grpc") return;
            
            var headers = DictionaryToString(context.Request.Headers);
            var routes = DictionaryToString(context.Request.RouteValues);
            
            _logger.LogInformation($"Request's headers:\n{headers}\nRequest's routes:\n{routes}");
        }
        
        private void LogResponse(HttpContext context)
        {
            if (context.Request.ContentType == "application/grpc") return;

            var headers = DictionaryToString(context.Response.Headers);
            var routes = DictionaryToString(context.Request.RouteValues);
            
            _logger.LogInformation($"Response's headers:\n{headers}\nRequest's routes:\n{routes}");
        }
        
        private string DictionaryToString<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            var sb = new StringBuilder();
            foreach (var entry in dictionary)
            {
                sb.Append(entry.Key).Append(':').Append(entry.Value).Append('\n');
            }
            return sb.ToString();
        }
    }
}