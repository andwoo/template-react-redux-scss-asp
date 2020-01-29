using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace server
{
    public class Startup
    {
        public void Configure(IConfiguration configuration, IApplicationBuilder app, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                ConfigureDevelopmentServices(app, environment);
            }
            else
            {
                ConfigureProductionServices(app, environment);
            }

            ConfigureServices(app, environment);
        }

        private void ConfigureDevelopmentServices(IApplicationBuilder app, IHostingEnvironment environment)
        {
            app.UseDeveloperExceptionPage();
        }

        private void ConfigureProductionServices(IApplicationBuilder app, IHostingEnvironment environment)
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        private void ConfigureServices(IApplicationBuilder app, IHostingEnvironment environment)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
