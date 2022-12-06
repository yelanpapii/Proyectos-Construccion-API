using ProyectosConstruccion.Application.Models.Interfaces;
using ProyectosConstruccion.Negocio.DtoModels;

namespace ProyectosConstruccion.Application.Services.Interfaces
{
    public interface IUsersService
    {
        object Login(UserDTO user);
        IUserEntity FindUserFromDatabase(UserDTO user);
        IUserEntity FindUserFromDatabase(int id);
    }
}