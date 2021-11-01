using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.Platform.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next) { }

        public async Task InvokeAsync(HttpContext context)
        {
            var sb = new StringBuilder();
            sb.Append("version: ")
                .Append(Assembly.GetExecutingAssembly().GetName().Version?.ToString())
                .Append(", serviceName: ")
                .Append(Assembly.GetExecutingAssembly().GetName().Name);
            
            await context.Response.WriteAsync(sb.ToString());
        }
    }
}