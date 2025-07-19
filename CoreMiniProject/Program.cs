using System;
using CoreMiniProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreMiniProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddScoped<ICustomerDAL, CustomerDAL>();


            builder.Services.AddScoped<ICustomerDAL, CustomerSqlDAL>();

            //            builder.Services.AddDbContext<CoreMini>(options =>
            //    options.UseSqlServer(
            //        builder.Configuration.GetConnectionString("ConStr"),
            //        sqlOptions => sqlOptions.EnableRetryOnFailure()
            //    )
            //);
            
            builder.Services.AddDbContext<CoreMini>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));


            // To connect which dataabase

            ////            builder.Services.AddDbContext<CoreMiniProjectDbContext>(options =>
            ////    options.UseSqlServer(
            ////        builder.Configuration.GetConnectionString("ConStr"),
            ////        sqlOptions => sqlOptions.EnableRetryOnFailure()
            ////    )
            ////);
            ///

            //builder.Services.AddDbContext<CoreMini>(options =>
            //        options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr"), options => options.EnableRetryOnFailure(
            //        maxRetryCount: 5,
            //        maxRetryDelay: System.TimeSpan.FromSeconds(120),
            //        errorNumbersToAdd: null)));



            //        builder.Services.AddDbContext<CoreMini>(options =>
            //options.UseSqlServer(
            //    builder.Configuration.GetConnectionString("ConStr"),
            //    sqlServerOptions =>
            //    {
            //        sqlServerOptions.EnableRetryOnFailure(
            //            maxRetryCount: 5,
            //            maxRetryDelay: TimeSpan.FromSeconds(10),
            //            errorNumbersToAdd: null);
            //    }));

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
                pattern: "{controller=Test}/{action=DisplayCustomers}/{id?}");

            app.Run();
        }
    }
}
