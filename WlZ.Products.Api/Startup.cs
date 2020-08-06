using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WlZ.Products.Api.Models.Entities;
using WlZ.Products.Api.Data.Repositories;
using WlZ.Products.Api.Data.Repositories.Interfaces;
using AutoMapper;

namespace WlZ.Products.Api
{
    public class Startup
    {
        readonly string MyCors = "MyCors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddCors(options => {
                options.AddPolicy(name: MyCors,
                    builder =>
                    {
                        builder.WithHeaders("*");
                        builder.WithOrigins("*");
                        builder.WithMethods("*");
                    });
            });

            services.AddControllers();

            this.DependenceInjections(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyCors);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void DependenceInjections(IServiceCollection services)
        {
            services.AddScoped<DbContext, WLZ_ProductsContext>();

            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddScoped<IMapper, Mapper>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        }
    }
}
