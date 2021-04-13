using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using contractors.Repositories;
using contractors.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;
namespace contractors
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "contractors", Version = "v1" });
            });
            services.AddScoped<IDbConnection>(x => CreateDbConnection());
            //PROFILES
            services.AddTransient<ProfilesService>();
            services.AddTransient<ProfilesRepository>();
            //CONTRACTORS
            services.AddTransient<ContractorsService>();
            services.AddTransient<ContractorsRepository>();
            //JOBS
            services.AddTransient<JobsService>();
            services.AddTransient<JobsRepository>();
            //BOTH
            services.AddTransient<ContractorsJobsService>();
            services.AddTransient<ContractorsJobsRepository>();
        }

        private IDbConnection CreateDbConnection()
        {
            var connectionString = Configuration["db:gearhost"];
            return new MySqlConnection(connectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "contractors v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}
