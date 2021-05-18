using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Movies_APIs.CustomActionFilters;
using Movies_APIs.Entities.Contaxt;
using Movies_APIs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Movies_APIs
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

            services.AddDbContext<ApplicationDbContaxt>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //services.AddControllers();

            // Application Custom Exception  Filter
            services.AddControllers(options=> {
                options.Filters.Add(typeof(MyExceptionFilter));
            });

            services.AddResponseCaching(); // For Storing the Data into cacsh

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();


            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movies_APIs", Version = "v1" });
            });

            services.AddScoped<IRepository, GenresRepository>();

            // Add Custom Action Filter

            services.AddTransient<MyActionFilter>();


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader().AllowAnyMethod();
                });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies_APIs v1"));

            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseResponseCaching();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
