using CleaningManagement.Api.Middleware;
using CleaningManagement.Api.Validators;
using CleaningManagement.DAL;
using CleaningManagement.DAL.Abstraction.Repositories;
using CleaningManagement.DAL.Repositories;
using CleaningManagement.Services.Abstraction.Services;
using CleaningManagement.Services.Profiles;
using CleaningManagement.Services.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CleaningManagement.Api
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
            services.AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblyContaining<CreateCleaningPlanRequestValidator>();
            });
            
            services.AddDbContext<CleaningManagementDbContext>();
            services.AddTransient<ICleaningPlanRepository, CleaningPlanRepository>();
            services.AddTransient<ICleaningPlanService, CleaningPlanService>();
            services.AddAutoMapper(typeof(CleaningPlanProfile), typeof(Profiles.CleaningPlanProfile));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleaningManagementApi", Version = "v1" });                
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            
            app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
