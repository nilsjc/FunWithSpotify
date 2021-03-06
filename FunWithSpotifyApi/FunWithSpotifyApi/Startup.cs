﻿using FunWithSpotifyApi.Interfaces;
using FunWithSpotifyApi.Repositories;
using FunWithSpotifyApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunWithSpotifyApi
{
    public class Startup
    {
        private const string LoginPath = "/Login";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();
            Configuration.Bind(appSettings);
            services.AddSingleton(appSettings);
            services.AddScoped<ISpotifyApiClient, SpotifyApiClient>();
            services.AddScoped<ISpotifyQueryBuilder, SpotifyQueryBuilder>();
            services.AddScoped<IAudioFeatureRepository, AudioFeatureRepository>();
            services.AddScoped<IRecommendationBuilder, RecommendationBuilder>();

            services.AddSingleton<QuestionRepository>();

            services.AddMemoryCache();

            services.AddSession();

            services.AddDistributedMemoryCache();
           
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute
                (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
