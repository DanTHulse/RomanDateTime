using API.RomanDate.Mappings.Profiles;
using API.RomanDate.Middleware;
using API.RomanDate.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.RomanDate
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private MapperConfiguration AutoMapperConfig { get; set; }

        public Startup(IConfiguration configuration)
        {
            this.AutoMapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new RomanDateMapping());
            });

            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddControllers();

            _ = services.Scan(s => s.FromAssemblyOf<IService>()
                    .AddClasses(c => c.AssignableTo<IService>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
            _ = services.AddSingleton(x => this.AutoMapperConfig.CreateMapper());
            _ = services.AddScoped<Mappings.Interfaces.IMapper, Mappings.Mapper>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }

            _ = app.UseMiddleware(typeof(ErrorHandlerMiddleware));

            _ = app.UseHttpsRedirection();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });
        }
    }
}
