using ProyectosConstruccion.Negocio.DtoModels;

namespace ProyectosConstruccion.Application.Services.Interfaces
{
    public interface IUsersService
    {
        object Login(UserDTO user);
    }
}