using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportSystem.Data.Dbcontexts;
using TransportSystem.Data.Entities;
using TransportSystem.Service.BusesServices;
using TransportSystem.Service.HomePageServices;
using TransportSystem.Service.TerminalServices;

namespace TransportSystem
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
            services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TransportSystem"), 
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("TransportSystem.Data");
                }));
            services.AddScoped<ITerminalService, TerminalService>();
            services.AddScoped<IBusService, BusService>();
            services.AddScoped<IHomePageService, HomePageService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 7;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
            });
            services.AddControllersWithViews();
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
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
