using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectosConstruccion.Application.Models;
using ProyectosConstruccion.Application.Services.Interfaces;
using ProyectosConstruccion.Negocio.DtoModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ProyectosConstruccion.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IConfiguration _configuration;

        public UsersService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public object Login(UserDTO user)
        {
            string name = user.Name.ToString();
            string pass = user.Password.ToString();

            User current = User.InitializeDb().FirstOrDefault(x => x.Name == name && x.Password == pass);

            if(current is null)
            {
                return new
                {
                    Success = false,
                    Message = "Credenciales Incorrectas",
                    Result = ""
                };
            }

            //Mover a una clase helper
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", current.Id.ToString()),
                new Claim("Name", current.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var sigin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer, jwt.Audience, claims,expires: DateTime.UtcNow.AddHours(1), signingCredentials: sigin);

            return new
            {
                success = true,
                message = "Success",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
