
using Microsoft.EntityFrameworkCore;
using PaintyTestTask.API.Data;
using PaintyTestTask.Data;
using PaintyTestTask.Data.Repositories;
using PaintyTestTask.Entities;
using PaintyTestTask.Helpers;
using PaintyTestTask.Interfaces.Repositories;

namespace PaintyTestTask.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("MSSQL");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
            builder.Services.AddTransient<DataDbInitializer>();
            
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


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
        
    }
}