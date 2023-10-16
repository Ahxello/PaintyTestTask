using Microsoft.EntityFrameworkCore;
using PaintyTestTask.Data.Repositories;
using PaintyTestTask.Data;
using PaintyTestTask.Interfaces.Repositories;
using PaintyTestTask.Entities;

namespace PaintyTestTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration.GetConnectionString("MSSQL");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
            builder.Services.AddTransient<IRepository<User>, Repository<User>>();
            builder.Services.AddTransient<IRepository<Picture>, Repository<Picture>>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}