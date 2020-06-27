using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TIM_Server.Core.IRepositories;
using TIM_Server.Infrastructure.Authorization;
using TIM_Server.Infrastructure.Database;
using TIM_Server.Infrastructure.Repositories;
using TIM_Server.Services.IServices;
using TIM_Server.Services.Services;

namespace TIM_Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            #region Database

            services.Configure<SqlOptions>(Configuration.GetSection("Sql"));
            services.AddDbContext<DatabaseContext>();

            #endregion

            #region Jwt

            var jwtSection = Configuration.GetSection("Jwt");
            services.Configure<JwtOptions>(jwtSection);
            var jwtOptions = new JwtOptions();
            jwtSection.Bind(jwtOptions);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
                        ValidIssuer = jwtOptions.Issuer,
                        ValidateAudience = false,
                        ValidateLifetime = jwtOptions.ValidateLifetime
                    };
                });

            #endregion

            #region Repositories

            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ISoldierRepository, SoldierRepository>();
            services.AddScoped<ICommanderRepository, CommanderRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();

            #endregion

            #region Services

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IOutgoingBookService, OutgoingBookService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ISoldierService, SoldierService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IJwtHandler, JwtHandler>();

            #endregion

            services.AddControllers();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(x => x.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            DatabaseInitializer.PrepPopulation(app).Wait();

            //app.UseErrorHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
