using System;
using System.Linq;
using Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Data.Models;

namespace Data {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            // string connectionString = Configuration.GetConnectionString("Connection");
            string connectionString = Configuration.GetValue<string> ("ConnectionStrings:ReactLab");
            Console.WriteLine (connectionString);

            services.AddDbContext<ReactLabContext> (
                dbContextOptions => dbContextOptions
                .UseMySql (connectionString));

            services.AddScoped<IRepository<Store, long>, StoreRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {

        }
    }
}