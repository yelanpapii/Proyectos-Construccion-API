﻿namespace ProyectosConstruccion.Negocio.Services.Interfaces
{
    public interface IPaginationFilter
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}