using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConfigurationSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        //Để đọc cấu hình, chúng ta cần thể hiện của IConfiguration.
        //Chúng ta có thể dùng dependency injection để lấy thể hiện của nó trong constructor của Startup class. 
        //Bạn có thể dùng kỹ thuật này tương tự với Controller.
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        

        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    //await context.Response.WriteAsync("Hello World!");
                    await context.Response.WriteAsync(Configuration.GetSection("Message").Value);

                    // Đọc Connection String: Nhánh cha, con
                    //await context.Response.WriteAsync(Configuration.GetSection("ConnectionStrings:MySQLConnection").Value);
                    await context.Response.WriteAsync("<div>" + Configuration.GetSection("ConnectionStrings:MySQLConnection").Value + "</div>");

                    //Đọc mảng từ file cấu hình
                    await context.Response.WriteAsync("<div>" + Configuration.GetSection("wizards:0:Name").Value + "</div>");
                });
            });
        }
    }
}
