using CallForPappersService_PL.Middlware;
using CallForPappersService_DAL.Repository;
using CallForPappersService_BAL.Services;
using CallForPappersService_BAL.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using CallForPappersService_DAL.Data;
using CallForPappersService_BAL.Dto;
using CallForPappersService_DAL.Data.Entities;
using Serilog;

namespace CallForPappersService_PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            
            builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
            builder.Services.AddScoped<IActivityRepository, ActivityRepository>();

            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddScoped<IActivityService, ActivityService>();
            
            builder.Services.AddScoped<IValidator<ApplicationCreateDto>, ApplicationCreateDtoValidator>();
            builder.Services.AddScoped<IValidator<ApplicationUpdateDto>, ApplicationUpdateDtoValidator>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            builder.Services.AddSerilog(logger);

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.Migrate();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}