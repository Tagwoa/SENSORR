using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;


namespace SensorrService
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel
                .Information()
                .WriteTo.RollingFile("log-{Date}.txt", LogEventLevel.Information)
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();                
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.      
        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);           
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.       
    
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(minLevel: LogLevel.Warning);
            loggerFactory.AddSerilog();

            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) => {
                await context.Response
                .WriteAsync(_config["MyKey"]);
            });

            app.UseHttpsRedirection();
            app.UseMvc(); 
        }
    }
}
