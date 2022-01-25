using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace simpleWebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ConsoleLoggerMiddleware>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/favicon.ico", (app) => { });
            app.Map("/map", MapHandler); //http://localhost:5186/map
            app.UseMiddleware<ConsoleLoggerMiddleware>();
            app.UseWhen(context => context.Request.Query.ContainsKey("q"), HandleRequestWithQuery); //http://localhost:5186/test?q=ttest

            app.Run(async context =>
            {
                Console.WriteLine("Hello World");
                await context.Response.WriteAsync("Hello World");
            });

        }

        private void HandleRequestWithQuery(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                Console.WriteLine("Contains Query");
                await next();
            });
        }

        private void MapHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                Console.WriteLine("Hello for Map Method");
                await context.Response.WriteAsync("Hello from Map Method");
            });
        }
    }
}
