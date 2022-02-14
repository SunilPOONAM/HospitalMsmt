using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Hospital.DBServices.FAQ;
using Hospital.DBServices.Features;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hospital.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Hospital.DBServices.SuperAdmin; 
using Hospital.DBServices.HospitalAdmin;

namespace Hospital
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

            //string con = "Server=MAC; Database=Hospital; trusted_connection=true;";
            //services.AddDbContext<HMSContext>(options => options.UseSqlServer(con)); 
            //string cs = "Data Source=38.17.55.191;initial catalog=Hospital;user id=sa;password=BigNone123;";
            //services.AddDbContext<HMSContext>(options => options.UseSqlServer(cs)); 
            //string cs = "Data Source=DESKTOP-G95SLKK;Initial Catalog=Hospital;Integrated Security=True";
            //services.AddDbContext<HMSContext>(options => options.UseSqlServer(cs));

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddDbContext<HMSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<HMSContext>()
                .AddDefaultTokenProviders();  
            services.AddMvc();
            services.AddSession();
            services.AddTransient<HMSContext>();
            services.AddTransient<IEmailSender, SendMail>();
            services.AddTransient<IManageFAQService, ManageFAQService>();
            services.AddTransient<IFeatureService, FeatureService>();
            services.AddTransient<IFAQService, FAQService>();
            services.AddTransient<ISuperAdmin, SuperAdmin>();
            services.AddTransient<IHospitalAdmin, HospitalAdmin>();
            services.AddAuthorization(options =>
            {
                //options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });
            

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
