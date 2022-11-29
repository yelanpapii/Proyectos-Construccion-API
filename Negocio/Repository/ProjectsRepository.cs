using Microsoft.EntityFrameworkCore;
using ProyectosConstruccion.Negocio.Repository.Interfaces;
using ProyectosConstruccion.Persistencia.DataContext;
using ProyectosConstruccion.Persistencia.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectosConstruccion.Negocio.Repository
{
    public class ProjectsRepository : IProjectRepository
    {
        private readonly proyectoconstruccionContext _context;

        public ProjectsRepository(proyectoconstruccionContext context)
        {
            _context = context;
        }

        public async Task<int> CountProjectsAsync()
        {
            return await _context.Proyectos
                .CountAsync();
        }
        public async Task<IEnumerable<Proyecto>> GetAllProjectsAsync(int pageNumber, int pageSize)
        {
            return await _context.Proyectos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Proyecto> GetProjectById(int id)
        {
            return await _context.Proyectos
               .Include(p => p.Compras)
               .FirstOrDefaultAsync(p => p.IdProyecto == id);
        }

        public async Task<object> GetProjectsBySelectLoading(int id)
        {
            return await _context.Proyectos.Select(p => new
            {
                Id = p.IdProyecto,
                Nombre_Proyecto = p.Constructora,
                Estrato_Proyecto = p.IdTipoNavigation.Estrato,
                Nombre_Lider = p.IdLiderNavigation.Nombre,
                Apellido_Lider = p.IdLiderNavigation.SegundoApellido,
                Rank_Lider = p.IdLiderNavigation.Clasificacion,
                Materiales = p.Compras.Select(pa => new
                {
                    Nombre_Material = pa.IdMaterialConstruccionNavigation.NombreMaterial,
                    Importado = pa.IdMaterialConstruccionNavigation.Importado
                })
            }).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}