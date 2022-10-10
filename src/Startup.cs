using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    /// <summary>
    /// start up class for the website
    /// </summary>
    public class Startup
    {
        //declare variables
        public IConfiguration Configuration { get; }

        /// <summary>
        /// constructor, initializing the config object
        /// IConfiguration configuration: represents a set of key/value application configuration properties
        /// </summary>
        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;

        }



        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// IServiceCollection services: Specifies the contract for a collection of service descriptors
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddServerSideBlazor();

            services.AddHttpClient();

            services.AddControllers();

            // Telling ths system about this service for the Plant Gallery
            services.AddTransient<JsonFilePlantService>();

            // Telling ths system about this service for the QnA
            services.AddTransient<JsonFileQnAService>();

            // Telling ths system about this service for the Plant Type
            services.AddTransient<JsonFilePlantTypeService>();

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// IApplicationBuilder app: define a class that provides mechanisms to configure
        /// an application's request pipeline
        /// IWebHostEnvironment env: provides information about the webhosting environment an
        /// an application is run in
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();

            }

            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }

            app.UseStatusCodePagesWithRedirects("/404Error");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapRazorPages();

                endpoints.MapControllers();

                endpoints.MapBlazorHub();

            }

            );

        }

    }

}