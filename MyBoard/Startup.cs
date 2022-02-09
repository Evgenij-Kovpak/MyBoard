using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyBoard.Data;
using MyBoard.Data.Interfaces;
using MyBoard.Data.Mocks;
using MyBoard.Data.Models;
using MyBoard.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard
{
    public class Startup
    {

        private IConfigurationRoot _confString;
        public Startup(IWebHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllProducts, ProductRepository>();
            services.AddTransient<IProductCategory, CategoryRepository>();
            services.AddTransient<IAllOrder, OrdersRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient(sp => ProductCart.GetCart(sp));
            services.AddRouting();


            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "CategoryFilter", template: "Product/{action}/{category?}", defaults: new { Controller = "Product", action = "List"});
            });


            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext context;
                context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                DBObjects.Initial(context);
            }
        }
    }
}
