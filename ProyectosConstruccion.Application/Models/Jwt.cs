using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;

namespace ProyectosConstruccion.Application.Models
{
    public sealed class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        public static Response<User> GetUserFromToken(ClaimsIdentity identity)
        {
            try
            {
                var id = identity.Claims.FirstOrDefault(x => x.Type == "Id").Value;

                var currentUser = User.InitializeDb().FirstOrDefault(x => x.Id == int.Parse(id));

                return new Response<User>
                {
                    Data = currentUser,
                    Succeded = true,
                    Message = "Success"
                };
            }
            catch (Exception)
            {
                //logger here
                throw;
            }
        }
    }
}
