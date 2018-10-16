using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AppCocacolaNayWebSrv.Models;

namespace AppCocacolaNayWebSrv
{
    public class Startup
    {
        public Startup(IConfiguration FicPaConfiguration)
        {
            FicLoConfiguration = FicPaConfiguration;
        }

        public IConfiguration FicLoConfiguration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<FicDBContext>(options =>
                   options.UseSqlServer(FicLoConfiguration.GetConnectionString("AppEvaWebSrvContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=FicIndex}/{action=Index}");

            });
        }
    }
}
