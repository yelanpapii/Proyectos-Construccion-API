using System;

namespace ProyectosConstruccion.Negocio.Services.Interfaces
{
    public interface IUriService 
    {
        public Uri GetPageUri(IPaginationFilter filter, string route);
    }
} 