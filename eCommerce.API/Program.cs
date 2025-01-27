using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using eCommerce.Core.Mapping;
using FluentValidation.AspNetCore;
namespace eCommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to DI container
            builder.Services.AddInfrastructure();
            builder.Services.AddCore();
            builder.Services.AddAutoMapper(typeof(AuthenticationConfig).Assembly);
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            // Add controllers to the DI container
            builder.Services.AddControllers();

            //build the app
            var app = builder.Build();

            //exception handling middleware
            app.UseExceptionHandlingMiddleware();


            //Routing
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("AllowAll");
            // Add authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
