using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EasyHome.Data;
using EasyHome.Data.Repositories;
using EasyHome.Shared;
using EasyHome.Core.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EasyHome.Core.Profiles;

namespace EasyHome
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddDbContext<EasyHomeDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EasyHomeConnection_Local")));


            services.AddScoped<IFUTPlayerRepository, FUTPlayerRepository>();
            services.AddScoped<IFUTPlayerService, FUTPlayerService>();

            services.AddScoped<IMSFCharacterRepository, MSFCharacterRepository>();
            services.AddScoped<IMSFCharacterService, MSFCharacterService>();

            services.AddScoped<IMSFTeamRepository, MSFTeamRepository>();
            services.AddScoped<IMSFTeamService, MSFTeamService>();

            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FUTProfile());
                cfg.AddProfile(new MSFProfile());
            }).CreateMapper());

        }

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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

        }
    }
}
