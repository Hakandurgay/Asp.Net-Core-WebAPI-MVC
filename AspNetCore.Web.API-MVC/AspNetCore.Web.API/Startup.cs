using AspNetCore.Web.Core.Repositories;
using AspNetCore.Web.Core.Service;
using AspNetCore.Web.Core.UnitOfWorks;
using AspNetCore.Web.Data;
using AspNetCore.Web.Data.Repositories;
using AspNetCore.Web.Data.UnitOfWorks;
using AspNetCore.Web.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Web.API.DTOs;
using AspNetCore.Web.API.Extensions;
using AspNetCore.Web.API.Filters;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AspNetCore.Web.API
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


            services.AddAutoMapper(typeof(Startup));
          
            services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
            services.AddScoped(typeof(IServiceGeneric<>), typeof(ServiceGeneric<>));
            services.AddScoped<ICategoryService, CategoryService >();
            services.AddScoped<IProductService, ProductService >();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<NotFoundFilter>(); //not found filter classý içinde dependency injection ile nesne aldýðý için burada tanýmlandý

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o => { o.MigrationsAssembly("AspNetCore.Web.Data"); });
            });

            services.AddControllers();
            services.Configure< ApiBehaviorOptions > (options =>
            {
                options.SuppressModelStateInvalidFilter = true;   //filterlarý kontrol etmez bizim yazacaðýmýzý beliritir asp.net core un default hatalarýný engeller
            });

            //services.AddControllers(o =>          default olarak bütün controllerda filterý tanýmlar
            //{
            //    o.Filters.Add(new ValidationFilter());
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomException();  //extension metod


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
