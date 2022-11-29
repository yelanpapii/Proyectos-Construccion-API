using ProyectosConstruccion.Negocio.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectosConstruccion.Negocio.Services.Interfaces
{
    public interface IProjectsService
    {
        public Task<int> CountProjectsAsync();
        public Task<IEnumerable<ProyectoDTO>> GetAllProjectsAsync(int PageNumber, int PageSize);

        public Task<ProyectoDTO> GetProjectByIdAsync(int id);

        public Task<object> GetProjectBySelectLoadingAsync(int id);
    }
}