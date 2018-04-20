using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NetCore_GigHub.Data;
using NetCore_GigHub.Entities;
using System.Text;

namespace NetCore_GigHub
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddIdentity<User, UserRole>(options =>
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
                            ValidIssuer = _configuration["Jwt:Issuer"],
                            ValidAudience = _configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                        };
                    });


            services.AddDbContext<ContextGigHub>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("GigHub"));
            });

            services.AddMvc();
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
    }
}
