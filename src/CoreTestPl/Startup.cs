﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using CoreTestPl.Services;
using CoreTestPl.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CoreTestPl
{
    public class Startup
    {
        public Startup(IHostingEnvironment enviroment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(enviroment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            services.AddMvc();
            services.AddDbContext<OdeToFoodDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("OdeToFood")));
            services.AddIdentity<User, IdentityRole>(o => {
                    o.Cookies.ApplicationCookie.AutomaticChallenge = true; })
                    .AddEntityFrameworkStores<OdeToFoodDbContext>();
            services.Configure<CookieAuthenticationOptions>(o =>
            {
                o.LoginPath = "/Account/Login";
                o.AutomaticChallenge = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            IGreeter greeter)
        {
            loggerFactory.AddConsole();

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home";
                    await next();
                }
                else if (context.Response.StatusCode == 401)
                {
                    context.Response.StatusCode = 302;
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = context => context.Response.WriteAsync("Error")
                });
            }
            app.UseCookieAuthentication();
            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);
            app.UseIdentity();
            app.UseMvc(ConfigureRoutes);

            //app.Run(async (context) =>
            //{
            //    var message = greeter.GetGreeting() ;
            //    await context.Response.WriteAsync(message);
            //});
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
