using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SurfBreaks.Application.Interfaces;
using SurfBreaks.Application;
using Infrastructure.Persistence;
using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace TestSurf
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
            services.AddDbContextPool<SurfBreaksDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            // services.AddScoped<ISurfBreakData, SqlSurfBreakData>();

            //if (Configuration.GetValue<bool>("UseInMemoryDatabase"))
            //{
            //    services.AddDbContext<SurfBreaksDbContext>(options =>
            //        options.UseInMemoryDatabase("SurfBreaksDb"));
            //}
            //else
            //{
            //    services.AddDbContext<SurfBreaksDbContext>(options =>
            //        options.UseSqlServer(
            //            Configuration.GetConnectionString("DefaultConnection"),
            //            b => b.MigrationsAssembly(typeof(SurfBreaksDbContext).Assembly.FullName)));
            //}

            services.AddScoped<ISurfBreaksDbContext>(provider => provider.GetService<SurfBreaksDbContext>());
            //services.AddScoped<ISurfBreakData, SqlSurfBreakData>();
            services.AddSingleton<ISurfBreakData, InMemorySurfBreakData>();

            var assembly = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(assembly);

            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddHttpContextAccessor();

            services.AddControllersWithViews();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            //services.AddScoped<ISurfBreakData, InMemorySurfBreakData>();

            services.AddRazorPages();
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddApplication();
        //    services.AddMediatR(Assembly.GetExecutingAssembly());
        //    services.AddInfrastructure(Configuration);

        //    services.AddScoped<ICurrentUserService, CurrentUserService>();

        //    services.AddHttpContextAccessor();

        //    services.AddHealthChecks()
        //        .AddDbContextCheck<ApplicationDbContext>();

        //    services.AddControllersWithViews(options =>
        //        options.Filters.Add(new ApiExceptionFilter()));

        //    services.AddRazorPages();

        //    Customise default API behaviour
        //    services.Configure<ApiBehaviorOptions>(options =>
        //    {
        //        options.SuppressModelStateInvalidFilter = true;
        //    });

        //    In production, the Angular files will be served from this directory
        //    services.AddSpaStaticFiles(configuration =>
        //    {
        //        configuration.RootPath = "ClientApp/dist";
        //    });

        //    services.AddOpenApiDocument(configure =>
        //    {
        //        configure.Title = "SurfBreaks API";
        //        configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
        //        {
        //            Type = OpenApiSecuritySchemeType.ApiKey,
        //            Name = "Authorization",
        //            In = OpenApiSecurityApiKeyLocation.Header,
        //            Description = "Type into the textbox: Bearer {your JWT token}."
        //        });

        //        configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        //    });
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
