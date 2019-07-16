using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Implementacion.Banco;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Banco;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using static GestionObra.IoC.Inyeccion;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiObra
{
    public class Startup
    {
        private readonly string _myPolicy = "_myPolicy";
        public  Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;

            });


            services.AddCors(options =>
            {
                options.AddPolicy(_myPolicy, builder => builder.WithOrigins("*").WithMethods("*").WithHeaders("*").AllowCredentials());


            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<MvcOptions>(options => options.Filters.Add(new CorsAuthorizationFilterFactory(_myPolicy)));

            services.AddSwaggerGen(config => config.SwaggerDoc("V1", new Info
            {
                Title = "MiApi",
                Version = "V1",

            }));
            ConfigurationService(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/V1/swagger.json", "MiApiV1"));



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller-home}/{action = Index}/{id?}");
            });

            app.UseCors(_myPolicy);

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
