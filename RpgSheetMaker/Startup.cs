using Library.CommonObjects;
using Library.Implementations.CallOfCthulhu;
using Library.Implementations.Fallout;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
        private ILogMachine _logMachine;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath);

            Configuration = builder.Build();

            _hostingEnvironment = env;
            _logMachine = new LogMachine(env.ContentRootFileProvider);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var physicalProvider = _hostingEnvironment.ContentRootFileProvider;

            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials();
            }));

            services.AddMvc();

            services.AddTransient<ILogMachine, LogMachine>();
            services.AddSingleton<IFileProvider>(physicalProvider);
            services.AddSingleton<IRepository, FalloutRepository>();
            services.AddSingleton<IRepository, CallOfCthulhuRepository>();

            services.AddSingleton<CharacterFactory, FalloutCharacterFactory>();
            services.AddSingleton<CharacterFactory, CthulhuCharacterFactory>();

            services.AddSingleton<IArchivist, Archivist>();
            services.AddSingleton<ICharacterService, CharacterService>();
            services.AddSingleton<IGameService, GameService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.Use(async (context, next) =>
            {
                _logMachine.Log("Request incoming");
                foreach (var item in context.Request.Headers)
                {
                    _logMachine.Log("header " + item.Key + " : " + item.Value);
                }

                _logMachine.Log("Response incoming");
                foreach (var item in context.Response.Headers)
                {
                    _logMachine.Log("header " + item.Key + " : " + item.Value);
                }


                await next.Invoke();
            });

            app.UseMvc();
            
        }
    }
}
