using API.RomanDate.Infrastructure.IoC;
using API.RomanDate.Infrastructure.Middleware;
using API.RomanDate.Mappings.Profiles;
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
                config.AddProfile(new RomanDateMapping().Build());
                config.AddProfile(new MagistratesSimpleMapping().Build());
                config.AddProfile(new MagistratesFullMapping().Build());
                config.AddProfile(new ElectedOfficeMapping().Build());
                config.AddProfile(new CalendarMapping().Build());
                config.AddProfile(new CalendarMonthMapping().Build());
            });

            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddControllers();
            _ = services.Scan(s => s.FromAssemblyOf<ITransient>()
                    .AddClasses(c => c.AssignableTo<ITransient>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
            _ = services.Scan(s => s.FromAssemblyOf<IScoped>()
                    .AddClasses(c => c.AssignableTo<IScoped>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            _ = services.Scan(s => s.FromAssemblyOf<ISingleton>()
                    .AddClasses(c => c.AssignableTo<ISingleton>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());
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
