using graphql.poc.repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graphql.poc.server.middleware
{
    public static class MigrationDatabaseExtension
    {
        public static void UseMigrationDatabase<T>(this IApplicationBuilder builder) where T : DbContext
        {
            builder.UseMiddleware<MigrationDatabaseMiddleware<T>>(builder);
        }
    }

    public class MigrationDatabaseMiddleware<T> where T : DbContext
    {
        private readonly RequestDelegate _next;
        private readonly IApplicationBuilder _app;

        public MigrationDatabaseMiddleware(RequestDelegate next, IApplicationBuilder app)
        {
            _next = next;
            _app = app;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var serviceScope = _app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var ctx = serviceScope.ServiceProvider.GetService<T>())
                {
                    try
                    {
                        ctx.Database.Migrate();
                        await _next(context);
                        return;
                    }
                    catch
                    {
                        await _next(context);
                        return;
                    }
                }
            }
        }
    }
}
