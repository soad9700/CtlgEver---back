using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CtlgEver.Infrastructure.Data;
using CtlgEver.Infrastructure.EmailConfiguration;
using CtlgEver.Infrastructure.EmailConfiguration.Interfaces;
using CtlgEver.Infrastructure.EmailFactory;
using CtlgEver.Infrastructure.EmailFactory.Interfaces;
using CtlgEver.Infrastructure.JWT;
using CtlgEver.Infrastructure.Mappers;
using CtlgEver.Infrastructure.Repositories;
using CtlgEver.Infrastructure.Repositories.Interfaces;
using CtlgEver.Infrastructure.Services;
using CtlgEver.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CtlgEver.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<CtlgEverContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("CtlgEverDatabase"),
                    b => b.MigrationsAssembly ("CtlgEver.Api")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
            });
            
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute ());
            });

            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ISheetRepository,SheetRepository>();
            services.AddScoped<IJwtSettings,JwtSettings>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<ISheetService,SheetService>();
            services.AddScoped<IEmailConfiguration,EmailConfiguration>();
            services.AddScoped<IEmailFactory,EmailFactory>();
            services.AddScoped<IUserEmailFactory,UserEmailFactory>();

            services.AddSingleton(AutoMapperConfig.Initialize());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
