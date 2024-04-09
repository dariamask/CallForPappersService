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
            builder.Services.AddTransient<Seed>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            
            builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
            builder.Services.AddScoped<IActivityRepository, ActivityRepository>();

            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddScoped<IActivityService, ActivityService>();
            
            builder.Services.AddScoped<IValidator<ApplicationCreateDto>, ApplicationCreateDtoValidator>();
            builder.Services.AddScoped<IValidator<ApplicationUpdateDto>, ApplicationUpdateDtoValidator>();

            var app = builder.Build();

            app.UseMiddleware<CancellationHandlingMiddleware>();

            if (args.Length == 1 && args[0].ToLower() == "seeddata")
            {
                SeedData(app);
            }
            void SeedData(IHost app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

                using (var scope = scopedFactory.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<Seed>();
                    service.SeedDataContext();
                }
            }

            // Configure the HTTP request pipeline.
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