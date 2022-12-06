using Microsoft.Extensions.Configuration;
using ProyectosConstruccion.Application.Helpers;
using ProyectosConstruccion.Application.Models;
using ProyectosConstruccion.Application.Models.Interfaces;
using ProyectosConstruccion.Application.Services.Interfaces;
using ProyectosConstruccion.Negocio.DtoModels;
using System.Linq;

namespace ProyectosConstruccion.Application.Services
{
    public sealed class UsersService : IUsersService
    {
        private readonly IConfiguration _configuration;

        public UsersService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public object Login(UserDTO user)
        {
            var current = this.FindUserFromDatabase(user);
            if (current is null) return null;

            return JwtHelper.CreateJwtToken(_configuration, current);
        }

        public IUserEntity FindUserFromDatabase(UserDTO user)
        {
            IUserEntity current = User.InitializeDb().FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            
            return current;
        }

        public IUserEntity FindUserFromDatabase(int id)
        {
            IUserEntity current = User.InitializeDb().FirstOrDefault(x => x.Id == id);

            return current;
        }

    }
}