using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace custom
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.Use(async (context, next) =>
            {
                var profiler = new Stopwatch();
                profiler.Start();

                await Task.Delay(1000);

                await next();

                profiler.Stop();
                context.Response.Headers.Add("x-profiler-ms", profiler.ElapsedMilliseconds.ToString());
            });
        }
    }
}
