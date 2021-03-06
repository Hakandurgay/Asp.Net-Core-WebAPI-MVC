using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Web.Core.Repositories;
using AspNetCore.Web.Core.Service;
using AspNetCore.Web.Core.UnitOfWorks;
using AspNetCore.Web.Data;
using AspNetCore.Web.Data.Repositories;
using AspNetCore.Web.Data.UnitOfWorks;
using AspNetCore.Web.MVC.ApiService;
using AspNetCore.Web.MVC.Filters;
using AspNetCore.Web.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Web.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpClient<CategoryApiService>(options =>
            {
                options.BaseAddress=new Uri(Configuration["baseUrl"]);
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
            services.AddScoped(typeof(IServiceGeneric<>), typeof(ServiceGeneric<>));
            services.AddScoped<ICategoryService, CategoryService>();   //her lar��la�t���nda farkl� bir nesne �rne�i olu�turmas� i�in addtransient kullan�l�r
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();  
            services.AddControllersWithViews();

            services.AddScoped<NotFoundFilter>(); 

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o => { o.MigrationsAssembly("AspNetCore.Web.Data"); });
            });
        }

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
