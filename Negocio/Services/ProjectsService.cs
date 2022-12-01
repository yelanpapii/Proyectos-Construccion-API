using AutoMapper;
using ProyectosConstruccion.Negocio.DtoModels;
using ProyectosConstruccion.Negocio.Repository.Interfaces;
using ProyectosConstruccion.Negocio.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectosConstruccion.Negocio.Services
{
    public partial class ProjectsService : IProjectsService
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public ProjectsService(IProjectRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CountProjectsAsync()
        {
            return await _repository.CountProjectsAsync();
        }

        public async Task<IEnumerable<ProyectoDTO>> GetAllProjectsAsync(int PageNumber, int PageSize)
        {
            var proyectos = await _repository.GetAllProjectsAsync(PageNumber, PageSize);
            ICollection<ProyectoDTO> proyectoDTOs = new List<ProyectoDTO>();

            foreach (var proyecto in proyectos)
            {
                var maped = _mapper.Map<ProyectoDTO>(proyecto);
                proyectoDTOs.Add(maped);
            }

            return proyectoDTOs;
        }

        public async Task<ProyectoDTO> GetProjectByIdAsync(int id)
        {
            var proyecto = await _repository.GetProjectById(id);

            var ProyectResponse = _mapper.Map<ProyectoDTO>(proyecto);

            return ProyectResponse;
        }

        public async Task<object> GetProjectBySelectLoadingAsync(int id)
        {
            return await _repository.GetProjectsBySelectLoading(id);

        }
    }
}