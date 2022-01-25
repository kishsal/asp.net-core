using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class ConsoleLoggerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)  //Since there's an await, an async is required
    {
        Console.WriteLine("Request started");
        await next(context);
        Console.WriteLine("Request finished");
    }
}