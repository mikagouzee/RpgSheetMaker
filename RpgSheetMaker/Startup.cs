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

            services.AddMvc();

            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            }));

            services.AddTransient<ILogMachine, LogMachine>();
            services.AddSingleton<IFileProvider>(physicalProvider);
            services.AddSingleton<IRepository, FalloutRepository>();
            services.AddSingleton<IRepository, CallOfCthulhuRepository>();

            services.AddSingleton<CharacterFactory, FalloutCharacterFactory>();
            services.AddSingleton<CharacterFactory, CthulhuCharacterFactory>();

            services.AddSingleton<IArchivist, Archivist>();

            services.AddSingleton<IService, CharacterService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseCors("AllowAll");
        }
    }
}
