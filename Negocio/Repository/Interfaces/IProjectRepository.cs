using ProyectosConstruccion.Persistencia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectosConstruccion.Negocio.Repository.Interfaces
{
    public interface IProjectRepository
    {
        public Task<int> CountProjectsAsync();
        public Task<IEnumerable<Proyecto>> GetAllProjectsAsync(int PageNumber, int PageSize);
        public Task<Proyecto> GetProjectById(int id);
        public Task<object> GetProjectsBySelectLoading(int id);
        public Task AddProjectsAsync(Proyecto project);
        public void UpdateProject(Proyecto project);
        public void DeleteProject(Proyecto id);
    }
}
