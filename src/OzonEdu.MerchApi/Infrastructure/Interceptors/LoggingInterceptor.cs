using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace OzonEdu.MerchApi.Infrastructure.Interceptors
{
    public class LoggingInterceptor : Interceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var response = await base.UnaryServerHandler(request, context, continuation);
            _logger.LogInformation($"Grpc request:\n{request}\nGrpc response:\n{response}");
            return response;
        }
    }
}