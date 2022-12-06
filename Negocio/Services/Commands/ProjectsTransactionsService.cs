using ProyectosConstruccion.Negocio.DtoModels;
using ProyectosConstruccion.Persistencia.Models;
using System.Threading.Tasks;

namespace ProyectosConstruccion.Negocio.Services
{
    public partial class ProjectsService
    {
        //TODO: Implementar jwt
        public async Task AddProjectAsync(ProyectoDTO project)
        {
            var proyecto = _mapper.Map<Proyecto>(project);

            await _repository.AddProjectsAsync(proyecto);
        }

        public async Task UpdateProject(ProyectoDTO project)
        {
            var proyecto = _mapper.Map<Proyecto>(project);

            await _repository.UpdateProject(proyecto);
        }
        public async Task DeleteProject(ProyectoDTO project)
        {
            var proyecto = _mapper.Map<Proyecto>(project);

            await _repository.DeleteProject(proyecto);
        }
    }
}
