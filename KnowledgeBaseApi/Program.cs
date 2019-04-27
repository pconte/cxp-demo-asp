using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using KnowledgeBaseApi.Models;

namespace KnowledgeBaseApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                // .MigrateDatabase<ApiContext>()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        
        // public static IWebHost MigrateDatabase<T>(this IWebHost webHost) where T:DbContext
        // {
        //     var serviceScopeFactory = (IServiceScopeFactory)webHost
        //         .Services.GetService(typeof(IServiceScopeFactory));

        //     using (var scope = serviceScopeFactory.CreateScope())
        //     {
        //         var services = scope.ServiceProvider;

        //         var dbContext = services.GetRequiredService<T>();
        //         dbContext.Database.Migrate();
        //     }

        //     return webHost;
        // }
    }
}
