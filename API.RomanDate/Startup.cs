using API.RomanDate.Infrastructure;
using API.RomanDate.Infrastructure.IoC;
using API.RomanDate.Infrastructure.Middleware;
using API.RomanDate.Mappings.Profiles;
using API.RomanDate.Mappings.Profiles.Calendar;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace API.RomanDate
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        private MapperConfiguration AutoMapperConfig { get; set; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            this.AutoMapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new CalendarDayMapping().Build());
                config.AddProfile(new CalendarDayShortMapping().Build());
                config.AddProfile(new CalendarMonthMapping().Build());
                config.AddProfile(new CalendarMonthShortMapping().Build());
                config.AddProfile(new CalendarYearMapping().Build());

                config.AddProfile(new MagistratesSimpleMapping().Build());
                config.AddProfile(new MagistratesFullMapping().Build());
                config.AddProfile(new ElectedOfficeMapping().Build());

                config.AddProfile(new RomanMonthsMapping().Build());
            });

            builder.AddEnvironmentVariables();

            this.Configuration = builder.Build();
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
            _ = services.AddSingleton(this.Configuration);
            _ = services.Configure<AppSettings>(this.Configuration.GetSection("AppSettings"));
            _ = services.AddScoped(x => x.GetService<IOptionsSnapshot<AppSettings>>().Value);
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
