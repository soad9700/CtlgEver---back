using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CtlgEver.Infrastructure.Data;
using CtlgEver.Infrastructure.Mappers;
using CtlgEver.Infrastructure.Repositories;
using CtlgEver.Infrastructure.Repositories.Interfaces;
using CtlgEver.Infrastructure.Services;
using CtlgEver.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CtlgEver.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<CtlgEverContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("CtlgEverDatabase"),
                    b => b.MigrationsAssembly ("CtlgEver.Api")));

            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ISheetRepository,SheetRepository>();

            services.AddScoped<IUserService,UserService>();
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
