using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using movies.data;
using movies.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies.api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDBServices(this.Configuration);
            services.AddBusinessServices();

            services.AddSwaggerGen();
            //    c =>
            //{
            //    c.SwaggerDoc("V1", new OpenApiInfo
            //    {
            //        Version = "V1",
            //        Title = "Movies API",
            //        Description = "Search Movies,Peoples and TV Shows.",
            //        TermsOfService = new Uri("https://github.com/bulbul16"),
            //        Contact = new OpenApiContact
            //        {
            //            Name = "Bulbul Ahmed",
            //            Email = "bulbul.cse@outlook.com",
            //            Url = new Uri("https://github.com/bulbul16/movies-api")
            //        },
            //        License = new OpenApiLicense
            //        {
            //            Name = "Opensource BL License",
            //            Url = new Uri("https://github.com/bulbul16")
            //        },
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
