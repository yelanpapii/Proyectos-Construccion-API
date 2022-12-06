using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectosConstruccion.Application.Models;
using ProyectosConstruccion.Application.Models.Interfaces;
using ProyectosConstruccion.Application.Services.Interfaces;
using Serilog;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ProyectosConstruccion.Application.Helpers
{
    public class JwtHelper
    {
        /// <summary>
        /// Jwt token creation helper.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <returns>Jwt Token</returns>
        public static Response<object> CreateJwtToken(IConfiguration config, IUserEntity user)
        {
            //Bind jwt configuration(optional).
            var jwt = config.GetSection("Jwt").Get<Jwt>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var sigin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer, jwt.Audience, claims, expires: DateTime.UtcNow.AddHours(1), signingCredentials: sigin);

            return new Response<object>
            {
                Data = new JwtSecurityTokenHandler().WriteToken(token),
                Succeded = true,
                Message = "Success"
            };
        }

        /// <summary>
        /// Get users credentials and validate it.
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="usersService"></param>
        /// <returns></returns>
        public static Response<IUserEntity> GetUserFromToken(ClaimsIdentity identity, IUsersService usersService)
        {
            try
            {
                var id = identity.Claims.FirstOrDefault(x => x.Type == "Id").Value;

                var currentUser = usersService.FindUserFromDatabase(int.Parse(id));

                return new Response<IUserEntity>
                {
                    Data = currentUser,
                    Succeded = true,
                    Message = "Success"
                };
            }
            catch (Exception e)
            {
                Log.Error(e.StackTrace);
                throw;
            }
        }
    }
}