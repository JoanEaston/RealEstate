using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<RealEstateContext>(b => b.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IPropertyRepository, PropertyRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseRouting();
            app.UseCookiePolicy();
            app.UseMvcWithDefaultRoute();
            //     app.UseMvc(ConfigureRoute);

            //app.UseEndpoints(route =>
            //{
            //    route.MapControllerRoute(
            //        name: "default",
            //        template: "{controller = Home}/{action = index}/{id?}");
            //});
            //app.UseMvc(route =>
            //{
            //    route.MapRoute(
            //        name: "Default",
            //        template: "{controller = Home}/{action = Index}/{id?}");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});


        }

        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller = Home}/{action = Index}/{id?}");
        }
    }
}
