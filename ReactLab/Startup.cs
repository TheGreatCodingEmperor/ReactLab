using System;
using System.Reflection;
using Core;
using Core.Queries;
using Data;
using Data.Models;
using Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ReactLab {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            var assembly = AppDomain.CurrentDomain.Load ("Data");
            string connectionString = Configuration.GetValue<string> ("ConnectionStrings:ReactLab");
            services.AddDbContext<ReactLabContext> (
                dbContextOptions => dbContextOptions
                .UseMySql (connectionString));
            services.AddScoped<IRepository<Store, long>, StoreRepository> ();
            services.AddMediatR (typeof (GetAllStoreQuery));
            services.AddSwaggerGen ();
            services.AddControllersWithViews ();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles (configuration => {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Error");
            }
            app.UseSwagger ();
            app.UseSwaggerUI ();

            app.UseStaticFiles ();
            app.UseSpaStaticFiles ();

            app.UseRouting ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa (spa => {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment ()) {
                    // spa.UseReactDevelopmentServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer ("http://localhost:3000");
                }
            });
        }
    }
}