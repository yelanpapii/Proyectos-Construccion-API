using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectosConstruccion.Application.Models;
using ProyectosConstruccion.Filters;
using ProyectosConstruccion.Helpers;
using ProyectosConstruccion.Negocio.DtoModels;
using ProyectosConstruccion.Negocio.Services.Interfaces;
using Serilog;
using System;
using System.Security.Claims;
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
            var proyectos = await _projectsService.GetAllProjectsAsync(PageNumber: filter.PageNumber, filter.PageSize);
            var totalCount = await _projectsService.CountProjectsAsync();

            var response = PaginationHelper.CreatePagedResponse(proyectos, filtro, totalCount, _uriService, route);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            try
            {
                var proyecto = await _projectsService.GetProjectByIdAsync(id);
                return Ok(proyecto);
            }
            catch (Exception e)
            {
                Log.Error(e.StackTrace);
                return BadRequest("Cant find the project or project doesnt exist");
            }
        }

        //[HttpGet("select/{id}")]
        //public async Task<object> GetSelect(int id)
        //{
        //    return await _projectsService.GetProjectBySelectLoadingAsync(id);
        //}

        //-------------------Commands-------------------------
        [HttpPost]
        public async Task<ActionResult<string>> AddProject([FromBody] ProyectoDTO dto)
        {
            try
            {
                await _projectsService.AddProjectAsync(dto);
            }
            catch (Exception e)
            {
                Log.Error(e.StackTrace);
                return BadRequest("Cannot add project");
            }

            return Ok("Project Succesfully Added");
        }

        [HttpPut]
        public ActionResult<string> UpdateProject([FromBody] ProyectoDTO dto)
        {
            try
            {
                _projectsService.UpdateProject(dto);
            }
            catch (Exception e)
            {
                Log.Error(e.StackTrace);
                return BadRequest("Cannot update project");
            }

            return Ok("Project Succesfully Updated");
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<ActionResult<object>> DeleteProject(int id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var token = Jwt.GetUserFromToken(identity);
            var currentUser = token.Data;

            if (currentUser.Rol != "Administrador") return Unauthorized();

            try
            {
                var project = await _projectsService.GetProjectByIdAsync(id);
                if (project is null) return BadRequest("Project doesnt exists");

                _projectsService.DeleteProject(project);
            }
            catch (Exception e)
            {
                Log.Error(e.StackTrace);
                return BadRequest("Cannot delete project");
            }

            return Ok("Project Succesfully Deleted");
        }
    }
}