using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProyectosConstruccion.Persistencia.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            ////try
            ////{
            ////    configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("secrets.json").Build();
            ////}
            ////catch (Exception e)
            ////{
            ////    Console.WriteLine("Error al inicializar path secrets.json: " + e);
            ////}

            services.AddDbContext<proyectoconstruccionContext>(options =>
                 options.UseMySQL(configuration.GetConnectionString("Proyectos")
            ));

            return services;
        }

    }
}
