using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Purpose.Models;
using Purpose.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Purpose
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //private void CheckSameSite(HttpContext httpContext, CookieOptions options)
        //{
        //    options.SameSite = SameSiteMode.None;
        //    //if (options.SameSite == SameSiteMode.None)
        //    //{
        //    //    var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
        //    //    if (SameSite.BrowserDetection.DisallowsSameSiteNone(userAgent))
        //    //    {
        //    //        options.SameSite = SameSiteMode.Unspecified;
        //    //    }
        //    //}
        //}
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                    options.Cookie.IsEssential = true;
                });
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //    options.OnAppendCookie = cookieContext =>
            //        CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            //    options.OnDeleteCookie = cookieContext =>
            //        CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            //});
            services.AddCors();

            services.AddSignalR();

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<ApplicationContext>();

            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin());  // подключаем CORS
            app.UseCookiePolicy();
            app.UseAuthentication();    // подключение аутентификации
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
