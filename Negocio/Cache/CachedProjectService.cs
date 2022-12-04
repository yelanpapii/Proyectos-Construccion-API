using Microsoft.Extensions.Caching.Memory;
using ProyectosConstruccion.Negocio.DtoModels;
using ProyectosConstruccion.Negocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectosConstruccion.Negocio.Cache
{
    public class CachedProjectService : IProjectsService
    {
        private readonly IProjectsService _service;
        private readonly IMemoryCache _memoryCache;

        public CachedProjectService(IProjectsService service,
            IMemoryCache cache)
        {
            _service = service;
            _memoryCache = cache;
        }

        public async Task<IEnumerable<ProyectoDTO>> GetAllProjectsAsync(int PageNumber, int PageSize = 10)
        {
            return await _memoryCache.GetOrCreateAsync(PageNumber,
                 async entry =>
                 {
                     entry.SetSlidingExpiration(TimeSpan.FromMinutes(3));
                     entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                     return await _service.GetAllProjectsAsync(PageNumber: PageNumber, PageSize);
                 });
        }

        public async Task<ProyectoDTO> GetProjectByIdAsync(int id)
        {
            return await _memoryCache.GetOrCreateAsync(id,
                async entry =>
                {
                    entry.SetSize(100);
                    entry.SetSlidingExpiration(TimeSpan.FromMinutes(3));
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(7);
                    return await _service.GetProjectByIdAsync(id);
                });
        }

        public async Task<int> CountProjectsAsync()
        {
            return await _memoryCache.GetOrCreateAsync(new Guid().ToString(),
               async entry =>
               {
                   entry.SetSize(100);
                   entry.SetSlidingExpiration(TimeSpan.FromMinutes(3));
                   entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(7);
                   return await _service.CountProjectsAsync();
               });
        }

        public async Task AddProjectAsync(ProyectoDTO project)
        {
            await _service.AddProjectAsync(project);
        }

        public void UpdateProject(ProyectoDTO project)
        {
            _service.UpdateProject(project);
        }

        public void DeleteProject(ProyectoDTO project)
        {
            _service.AddProjectAsync(project);
        }

        public Task<object> GetProjectBySelectLoadingAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}