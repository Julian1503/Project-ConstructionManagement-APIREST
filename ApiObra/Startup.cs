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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Http;

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

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = "Julien",
                    ValidAudience = "Gonelec",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Llave_super_secreta"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<MvcOptions>(options => options.Filters.Add(new CorsAuthorizationFilterFactory(_myPolicy)));

            //services.AddHsts(options =>
            //{
            //    options.Preload = true;
            //    options.IncludeSubDomains = true;
            //    options.MaxAge = TimeSpan.FromDays(60);
            //});

            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            //    options.HttpsPort = 5001;
            //});

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("V1", new Info
                {
                    Title = "MiApi",
                    Version = "V1",

                });
            });
            ConfigurationService(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/V1/swagger.json", "MiApiV1"));
            app.Use(next => async context => {
                try
                {
                    await next(context);
                }

                catch
                {
                    // If the headers have already been sent, you can't replace the status code.
                    // In this case, throw an exception to close the connection.
                    if (context.Response.HasStarted)
                    {
                        throw;
                    }

                    context.Response.StatusCode = 401;
                }
            });
            app.UseAuthentication();

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

            //app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller-home}/{action = Index}/{id?}");
            });

            app.UseCors(_myPolicy);

            app.UseMvc();
        }
    }
}
