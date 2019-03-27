using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCTOnlineServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using GCTOnlineServices.Models.ViewModels;
using Stripe;

namespace GCTOnlineServices
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
            // adding stripe service for payments
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

            
            services.AddAutoMapper();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // mapping database to model GCTContext
            services.AddDbContext<GCTContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // configure identity with custom user
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<GCTContext>();

            // configure password settings and user name settings
            services.Configure<IdentityOptions>(options =>
            {
                //pasword
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                //user
                options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789. @-_";
                options.User.RequireUniqueEmail = true;
            });

            // application cookie configuration
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/AccessDenied";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
            });

            // add authorization policy
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IServiceProvider services)
        {
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.Initialize(services);
            //CreateUserRoles(services).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            IdentityResult roleResult;
            //Adding Admin Role
            //var roleCheck = await RoleManager.RoleExistsAsync("Manager");
            //if (!roleCheck)
            //{
            //create the roles and seed them to the database

            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            //ApplicationUser user = await UserManager.FindByEmailAsync("syedshanumcain@gmail.com");
            var user = new ApplicationUser();
            //string userPWD = "CannotCrackThis2019-";
            //user.UserName = "GCTManager";
            //user.Email = "madalinc.preda@gmail.com";

            string userPWD = "Cannot2019-";
            user.UserName = "Madalin Preda";
            user.Email = "mcp@gmail.com";

            IdentityResult chkUser = await UserManager.CreateAsync(user, userPWD);
            await RoleManager.CreateAsync(new IdentityRole("Customer"));
            await RoleManager.CreateAsync(new IdentityRole("SalesStaff"));
            await RoleManager.CreateAsync(new IdentityRole("Admin"));
            await RoleManager.CreateAsync(new IdentityRole("AgencyOrClub"));

            roleResult = await RoleManager.CreateAsync(new IdentityRole("Manager"));

            //Add default User to Role Admin    
            //if (chkUser.Succeeded)
            // await UserManager.AddToRoleAsync(user, "Manager");

            //roleCheck = await RoleManager.RoleExistsAsync("Admin");
            //if (!roleCheck)
            //{
            //    //create the roles and seed them to the database
            //    roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            //}

            //chkUser = await UserManager.CreateAsync(user, userPWD);
            //roleResult = await RoleManager.CreateAsync(new IdentityRole("AgencyOrClub"));
            // roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            //Add default User to Role Admin    
            if (chkUser.Succeeded && roleResult.Succeeded)
                await UserManager.AddToRoleAsync(user, "Manager");
        }

    }
}
