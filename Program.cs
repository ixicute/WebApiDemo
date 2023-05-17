
using Microsoft.EntityFrameworkCore;
using WebApiDemo.Data;
using WebApiDemo.Repos;
using WebApiDemo.Repos.IRepos;

namespace WebApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //add sqlserver connection
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            //add service (AddScoped) for Irepository and repository
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

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
    }
}