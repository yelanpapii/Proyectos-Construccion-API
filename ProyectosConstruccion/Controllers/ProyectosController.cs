using Microsoft.AspNetCore.Mvc;
using ProyectosConstruccion.Filters;
using ProyectosConstruccion.Helpers;
using ProyectosConstruccion.Negocio.DtoModels;
using ProyectosConstruccion.Negocio.Services.Interfaces;
using ProyectosConstruccion.Wrappers;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectosConstruccion.Controllers
{
    [ServiceFilter(typeof(LogFilter))]
    [Route("api/proyectos")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly IProjectsService _projectsService;
        private readonly IUriService _uriService;

        public ProyectosController(
            IProjectsService projects,
            IUriService uriService)
        {
            _projectsService = projects;
            _uriService = uriService;
        }

        /// <summary>
        /// Return all projetcs paginated.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProjects([FromQuery] PaginationFilter filter)
        {
            //Current pagination filter object
            var filtro = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var route = Request.Path.Value;
            var proyectos = await _projectsService.GetAllProjectsAsync(filter.PageNumber, filter.PageSize);
            var totalCount = await _projectsService.CountProjectsAsync();

            var response = PaginationHelper.CreatePagedResponse(proyectos, filtro, totalCount, _uriService, route);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var proyecto = await _projectsService.GetProjectByIdAsync(id);
            return Ok(new Response<ProyectoDTO>(proyecto));
        }

        [HttpGet("select/{id}")]
        public async Task<object> GetSelect(int id)
        {
            return await _projectsService.GetProjectBySelectLoadingAsync(id);
        }
    }
}