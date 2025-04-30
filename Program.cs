using BookLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Rewrite;

namespace BookLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BookstoreContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<BookstoreContext>();

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<BookLibrary.Filters.RequestLoggingFilter>();
            });

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            var rewriteOptions = new RewriteOptions()
                .AddRewrite("^store(?:/)?$", "Books/Index", skipRemainingRules: true)
                .AddRewrite("^store/details/(.*)$", "Books/Details/$1", skipRemainingRules: true);

            app.UseRewriter(rewriteOptions);

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();    
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
