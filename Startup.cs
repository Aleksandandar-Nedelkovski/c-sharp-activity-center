using System;
using System.Collections.Generic;
using BELTEXAM.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BELTEXAM {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<MyContext> (options => options.UseMySql (Configuration["DBInfo:ConnectionString"]));
            services.AddSession ();
            services.AddMvc ();
        }
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            app.UseSession();
            app.UseStaticFiles ();
            app.UseMvc ();
        }
    }
}