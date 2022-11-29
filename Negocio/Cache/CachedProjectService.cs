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

        public async Task<IEnumerable<ProyectoDTO>> GetAllProjectsAsync(int PageNumber, int PageSize)
        {
            return await _memoryCache.GetOrCreateAsync(PageNumber,
                 async entry =>
                 {
                     entry.SetSize(100);
                     entry.SetSlidingExpiration(TimeSpan.FromMinutes(3));
                     entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                     return await _service.GetAllProjectsAsync(int.Parse(entry.Key.ToString()), PageSize);
                 });
        }

        public async Task<object> GetProjectBySelectLoadingAsync(int id)
        {
            return await _memoryCache.GetOrCreateAsync(id,
                async entry =>
                {
                    entry.SetSize(100);
                    entry.SetSlidingExpiration(TimeSpan.FromMinutes(3));
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                    return await _service.GetProjectBySelectLoadingAsync(int.Parse(entry.Key.ToString()));
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
                    return await _service.GetProjectByIdAsync(int.Parse(entry.Key.ToString()));
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
    }
}