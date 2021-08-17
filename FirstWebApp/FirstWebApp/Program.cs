using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FirstWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            //CreateWebHostBuilder(args).Build().Run();
            CreateDefaultBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<Startup>();

        public static IWebHostBuilder CreateDefaultBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                .UseKestrel()                                           //1. Cấu hình Kestrel như là web server
                .UseContentRoot(Directory.GetCurrentDirectory())        //2. Đặt thư mục gốc của ứng dụng sử dụng Directory.GetCurrentDirectory()
                .ConfigureAppConfiguration((hostingContext, config) =>  //3. Load cấu hình từ:
                {
                    var env = hostingContext.HostingEnvironment;

                    //a. Load cấu hình từ appsettings.json
                    //b. Load cấu hình từ Appsettings.{Environment}.json
                    config
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)                          
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    //c. Load các cấu hình riêng(user secrets) khi chạy ứng dụng ở môi trường Development
                    if (env.IsDevelopment())
                    {
                        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                        if (appAssembly != null)
                        {
                            config.AddUserSecrets(appAssembly, optional: true);
                        }
                    }

                    //d. Load các biến môi trường(Environment Variables)
                    config.AddEnvironmentVariables();

                    //e. Đọc các tham số truyền vào ứng dụng qua Command line argument
                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureLogging((hostingContext, logging) =>      
                {
                    //4. Bật logging: Đoạn này đọc cấu hình phần logging từ các file cấu hình 
                    //   cho việc xuất thông tin log ra console và ra cửa sổ debug.  
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .UseIISIntegration()                                //5. Tích hợp Kestrel chạy với IIS
                .UseDefaultServiceProvider((context, options) =>    //6. Default Service Provider: Đoạn này cài đặt DI Container có sẵn và bạn có thể tùy biến các hành động của nó
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                })
                .UseStartup<Startup>();

            return builder;
        }
    }
}
