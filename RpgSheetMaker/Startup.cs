using Library.CommonObjects;
using Library.Implementations;
using Library.Implementations.CallOfCthulhu;
using Library.Implementations.Fallout;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using RpgSheetMaker.Repositories;
using RpgSheetMaker.Services;
using RpgSheetMaker.Tools;

namespace RpgSheetMaker
{
    public class Startup
    {
        private IHostingEnvironment _hostingEnvironment;
        public IConfigurationRoot Configuration { get; }
        

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath);

            Configuration = builder.Build();

            _hostingEnvironment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var physicalProvider = _hostingEnvironment.ContentRootFileProvider;

            //todo : change this to allow only Vue 
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials();
            }));

            services.AddMvc();

            services.AddTransient<ILogMachine, LogMachine>();
            services.AddSingleton(physicalProvider);
            services.AddSingleton<IArchivist, Archivist>();
            services.AddSingleton<IGameService, GameService>();
            services.AddSingleton<ICharacterService, CharacterService>();

            services.AddTransient<IRepository, Repository>();
            services.AddTransient<ICharacterFactory, CharacterFactory>();

            services.AddSingleton<IGame, FalloutGame>();
            services.AddSingleton<IGame, CallOfCthulhuGame>();

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseCors("AllowAll");

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Clacks-Overhead", "GNU Terry Pratchett");
                await next.Invoke();
            });

            //app.Use(async (context, next) =>
            //{
            //    _logMachine.Log("Request incoming");
            //    foreach (var item in context.Request.Headers)
            //    {
            //        _logMachine.Log("Request header " + item.Key + " : " + item.Value);
            //    }

            //    _logMachine.Log("Response incoming");
            //    foreach (var item in context.Response.Headers)
            //    {
            //        _logMachine.Log("Response header " + item.Key + " : " + item.Value);
            //    }


            //    await next.Invoke();
            //});

            app.UseMvc();
            
        }
    }
}
