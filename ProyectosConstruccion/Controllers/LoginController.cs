using Microsoft.AspNetCore.Mvc;
using ProyectosConstruccion.Application.Services.Interfaces;
using ProyectosConstruccion.Filters;
using ProyectosConstruccion.Negocio.DtoModels;

namespace ProyectosConstruccion.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(LogFilter))]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public LoginController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public object LogIn([FromBody] UserDTO user)
        {
            var validate = _usersService.Login(user);
            if (validate is null) return BadRequest("User doesnt exist");

            return _usersService.Login(user);
        }
    }
}