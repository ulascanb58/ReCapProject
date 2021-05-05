using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using CoreLayer.Utilities.Security.Hashing;
using CoreLayer.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace WebApi
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
            services.AddControllers();
            //IoC - Hangi interfacenin karþýlýðý nedir
            /*
            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserDAL, EfUserDAL>();

            services.AddSingleton<IRentalService, RentalManager>();
            services.AddSingleton<IRentalDAL, EfRentalDAL>();

            services.AddSingleton<ICustomerService, CustomerManager>();
            services.AddSingleton<ICustomerDAL, EfCustomerDAL>();

            services.AddSingleton<IColorService, ColorManager>();
            services.AddSingleton<IColorDAL, EfColorDAL>();

            services.AddSingleton<ICarService, CarManager>();
            services.AddSingleton<ICarDAL, EfCarDAL>();

            services.AddSingleton<IBrandService, BrandManager>();
            services.AddSingleton<IBrandDAL, EfBrandDAL>();*/

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<NTokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });


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
            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
