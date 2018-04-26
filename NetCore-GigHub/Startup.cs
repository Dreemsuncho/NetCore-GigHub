using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NetCore_GigHub.Data;
using NetCore_GigHub.Entities;
using NetCore_GigHub.Managers;
using NetCore_GigHub.Models;
using NetCore_GigHub.ViewModels;
using System.Text;

namespace NetCore_GigHub
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _GetJwtSettings();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_jwtSettings);

            services.AddIdentity<User, RoleUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ContextGigHub>();

            services.AddAuthentication()
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = _jwtSettings.Issuer,

                            ValidateAudience = true,
                            ValidAudience = _jwtSettings.Audience,

                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key))
                        };
                    });


            services.AddDbContext<ContextGigHub>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("GigHub"));
            });

            services.AddTransient<ManagerSecurity>();

            services.AddMvc().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<VmBaseValidator>();
                ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRewriter(new RewriteOptions()
                .AddRedirectToHttpsPermanent());

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=App}/{action=Index}/{id?}");
            });
        }


        private JwtSettings _GetJwtSettings() => new JwtSettings
        {
            Key = _configuration["JwtSettings:Key"],
            Issuer = _configuration["JwtSettings:Issuer"],
            Audience = _configuration["JwtSettings:Audience"],
            MinutesToExpiration = int.Parse(_configuration["JwtSettings:MinutesToExpiration"])
        };
    }
}
