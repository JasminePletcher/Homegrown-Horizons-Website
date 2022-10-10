using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    /// <summary>
    /// class for initializing the program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// main class
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();

        }

        /// <summary>
        /// accessing the startup class
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();

                }
                );

    }

}