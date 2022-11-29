using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using ProyectosConstruccion.Negocio.Cache;
using ProyectosConstruccion.Negocio.Repository;
using ProyectosConstruccion.Negocio.Repository.Interfaces;
using ProyectosConstruccion.Negocio.Services;
using ProyectosConstruccion.Negocio.Services.Interfaces;
using ProyectosConstruccion.Negocio.Services.PaginationExtensions;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMemoryCache();
            services.AddScoped<ProjectsService>();
            services.AddScoped<IProjectsService>(x => new CachedProjectService(x.GetRequiredService<ProjectsService>(), x.GetRequiredService<IMemoryCache>()));
            services.AddScoped<IProjectRepository, ProjectsRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IUriService>(o =>
            {
                //Current request accessor/Acceder al request
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                //Intercept current request
                var request = accessor.HttpContext.Request;

                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });

            return services;
        }
    }
}