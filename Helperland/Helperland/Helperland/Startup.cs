
using Helperland.Data;
using Helperland.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland
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
            services.AddDbContext<HelperlandsContext>();
            services.AddMvc();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IInsertUserRepository, InsertUserRepository>();
            services.AddScoped<IBookServiceRepository, BookServiceRepository>();
            services.AddScoped<IUserAddressRepository, UserAddressRepository>();
            services.AddScoped<ICustomerServiceRepository, CustomerServiceRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IServiceRequestRepository, ServiceRequestRepository>();
            services.AddScoped<IFavouriteAndBlockRepository, FavouriteAndBlockRepository>();
            services.AddScoped<IServiceProviderMySettingRepository, ServiceProviderMySettingRepository>();
            services.AddScoped<IAdminUserManagementRepository, AdminUserManagementRepository>();
            
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

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
