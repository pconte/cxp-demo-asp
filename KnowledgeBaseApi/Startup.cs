using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KnowledgeBaseApi.Models;
using Microsoft.AspNetCore.Http;

namespace KnowledgeBaseApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt =>
                opt.UseInMemoryDatabase("KnowledgeBase"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            var cachePeriod = env.IsDevelopment() ? "1" : "1";
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                }
            });
        }

        // public class ApiContextFactory : IDesignTimeDbContextFactory<ApiContext>
        // {
        //     public ApiContext CreateDbContext(string[] args)
        //     {
        //         var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
        //         optionsBuilder.UseSqlite("Data Source=KnowledgeBase.db");

        //         return new ApiContext(optionsBuilder.Options);
        //     }
        // }
    }
}
