using ProyectosConstruccion.Application.Models.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosConstruccion.Application.Models
{
    public sealed class User : IUserEntity
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Password { get; init; }
        public string  Rol { get; set; }

        //Hardcoded DB
        public static IEnumerable<User>? InitializeDb()
        {
            IEnumerable<User> users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    Name = "admin",
                    Password = "admin",
                    Rol = "Administrador"
                },
                new User
                {
                    Id = 2,
                    Name = "yelan",
                    Password = "pata",
                    Rol = "Usuario"
                }
            };

            return users;
        }
    }
}
