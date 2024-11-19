using LaboratoriumASPNET.Models;
using WebApplication1.Models;
using LaboratoriumASPNET.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();                         // dodać
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddDefaultIdentity<IdentityUser>()       // dodać
                .AddRoles<IdentityRole>()                             //
                .AddEntityFrameworkStores<AppDbContext>();     // 
            builder.Services.AddTransient<IContactService, EFContactService>();
            builder.Services.AddMemoryCache();                        // dodać
            builder.Services.AddSession();  
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
            app.UseAuthorization();                                  // dodać
            app.UseSession();                                        // dodać 
            app.MapRazorPages();        

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}