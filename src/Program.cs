
using BET.Infrastructure;
using BET.Services.Interfaces;
using BET.Services.Repositories;
using BET.Utilities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services.Repositories;

namespace BET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
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

        static void ConfigureServices(WebApplicationBuilder builder)
        {
            string connection = builder.Configuration.GetConnectionString("Default");
            Check.NotNull(connection, nameof(connection));
            builder.Services.AddDbContext<BEDbContext>(options => options.UseSqlServer(connection));
            builder.Services.AddScoped<IUnitOfWork<BEDbContext>, UnitOfWork<BEDbContext>>();
            builder.Services.AddTransient<IDeparmentRepository, DeparmentRepository>();
            builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddTransient<IDeparmentEmployeeRepository, DeparmentEmployeeRepository>();
        }
    }
}