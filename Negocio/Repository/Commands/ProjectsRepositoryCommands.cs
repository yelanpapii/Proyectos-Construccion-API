using ProyectosConstruccion.Negocio.Repository.Interfaces;
using ProyectosConstruccion.Persistencia.Models;
using System.Threading.Tasks;

namespace ProyectosConstruccion.Negocio.Repository
{
    public partial class ProjectsRepository : IProjectRepository
    {
        public async Task AddProjectsAsync(Proyecto project)
        {
            await _context.Proyectos.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProject(Proyecto project)
        {
            _context.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProject(Proyecto project)
        {
            _context.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
