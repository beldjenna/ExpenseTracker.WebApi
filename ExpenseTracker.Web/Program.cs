
using ExpenseTracker.Core.Entities;
using ExpenseTracker.Data;
using ExpenseTracker.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExpenseTracker.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            // Add services to the container. -- first part -- service configuration

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ExpenseTrackerDbContext>(options =>
            {
                options.UseSqlServer(
                configuration.GetConnectionString("DbContext"),
                providerOptions => providerOptions.EnableRetryOnFailure()
                )
                .EnableSensitiveDataLogging(); // should not be used in production, only for developement purpose
            }
             );

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();




            // Configure the HTTP request pipeline. -- second part -- middleware configuration

            var app = builder.Build();




            

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
