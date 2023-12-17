using BLL.Interfaces;
using BLL.Repostioes;
using DAL.ContextConfiguration;
using DAL.Moduls;
using DemoMvc.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMvc
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
            services.AddControllersWithViews();
            services.AddDbContext<Dbcontext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("defaltConnection"));
            });

            //services.AddScoped<IDepartmentRepostory, DepartmentRepostory>();
            //services.AddScoped<IEmployeeRepository, EmployeeRepositorycs>();
            services.AddScoped<IUnitOfWork, UniteOfWork>();
           
            services.AddAutoMapper(e => e.AddProfile(new ClientProfile()));
            services.AddAutoMapper(e => e.AddProfile(new GalleryProfile()));
            services.AddAutoMapper(e => e.AddProfile(new HairArtistProfile()));
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
                    pattern: "{controller=Gallery}/{action=Index}/{id?}");
            });
        }
    }
}
