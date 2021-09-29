using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;  // for the database

namespace MVCMovie
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // IServiceProvider is at the heart of Microsoft.Extensions.DependencyInjection, and it needs to have the services registered here,
        // in IServiceCollection, so that e.g. in SeedData.cs, we can get a MvcMovieContext using the IServiceProvider.GetRequiredService.

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllersWithViews();

            services.AddDbContext<MvcMovieContext>(
                options => options.UseNpgsql(
                    Configuration.GetConnectionString("MvcMovieContext")// reads from connection string in the appsettings.json file
                )
             );  // registers the database context for DI into the controller
        }
        
        // Previous SQLite code: 
        //{
        //    var connectionString = Configuration.GetConnectionString("MvcMovieContext"); 

        //    if (Environment.IsDevelopment())
        //    {
        //        options.UseSqlite(connectionString);
        //    }
        //    else
        //    {
        //        options.UseSqlServer(connectionString);
        //    }
        //});   


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
