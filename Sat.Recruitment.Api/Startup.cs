using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Data.Contracts;
using Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DataAccess;
using Business.Contracts;
using Business;

namespace Sat.Recruitment.Api
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
            services.AddControllers();
            services.AddSwaggerGen();
            AddDataProviders(services);
            AddDataAccessServices(services);
            AddManagers(services);
        }

        private void AddDataProviders(IServiceCollection services)
        {
            services.AddSingleton<IDataContext>(options =>
                new DataContext(Configuration.GetConnectionString("FilePath")));
        }

        private void AddDataAccessServices(IServiceCollection services)
        {
            services.AddScoped<IUserDataAccess, UserDataAccess>();
        }

        private void AddManagers(IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
