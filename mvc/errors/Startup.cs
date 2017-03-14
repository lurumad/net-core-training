using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace errors
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseStatusCodePages();
            // app.UseStatusCodePages(async context =>{
            //     await context.HttpContext.Response.WriteAsync($"Status code: {context.HttpContext.Response.StatusCode}");
            // }); 
            //app.UseStatusCodePagesWithRedirects("~/{0}.html");
            // app.UseStatusCodePagesWithReExecute("/statuscode/{0}");

            app.UseMvc(options => {
                options.MapRoute(
                    name: "default",
                     template: "{controller}/{action}/{id?}",
                      defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
