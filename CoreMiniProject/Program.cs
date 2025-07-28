using System;
using System.Diagnostics.Metrics;
using CoreMiniProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CoreMiniProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var builder = WebApplication.CreateBuilder(args);

            var builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                Args = args,
                WebRootPath = "publicroot" // your renamed static folder
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddScoped<ICustomerDAL, CustomerDAL>();


            builder.Services.AddScoped<ICustomerDAL, CustomerSqlDAL>();
            
            builder.Services.AddDbContext<CoreMini>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<CoreMini>();
            
            //By using IdentityUser and IDentityRole We will Tell which acesss we need to give which acesss which should not give

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) // Checks if the current environment is Development.
            {
                app.UseStatusCodePages();
                //app.UseStatusCodePagesWithRedirects("/ClientError/{0}"); // This  will show  number in the URL 
                app.UseStatusCodePagesWithReExecute("/ClientError/{0}"); // This will not show any  number int the URL
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
                app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Test}/{action=DisplayCustomers}/{id?}");

            app.Run();
        }
    }
}
