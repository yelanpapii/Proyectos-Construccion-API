using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosConstruccion.Application.Models.Interfaces
{
    public interface IUserEntity
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Password { get; init; }
        public string Rol { get; set; }
    }
}
