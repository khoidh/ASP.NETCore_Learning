using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MVCCoreApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();                    //v2.1
            services.AddControllersWithViews();     //v3.0
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseStaticFiles();

            // Khai bao MVC khong tuong minh
            //app.UseMvcWithDefaultRoute(); 

            // Khai bao MVC tuong minh
            app.UseEndpoints(endpoints =>
            {
                // Set Default is DefaultController
                endpoints.MapControllerRoute(
                    "home", "{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute("default", "{controller=Default}/{action=Index}/{id?}");

                // Set default la HomeController
                //endpoints.MapControllerRoute(
                //    "default",
                //    "{controller=Home}/{action=Index}/{id?}");

                // Set Area
                //endpoints.MapControllerRoute(
                //    "default",
                //    "admin/{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Failed to find route!");
                });
            });
        }
    }
}
