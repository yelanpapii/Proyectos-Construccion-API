using System.Collections.Generic;

namespace ProyectosConstruccion.Negocio.DtoModels
{
    public record ProyectoDTO(
        short IdProyecto,
        string FechaInicio,
        string Constructora,
        decimal? NumeroBanos,
        decimal? NumeroHabitaciones,
        string BancoVinculado,
        decimal? PorcentajeCuotaInicial,
        string Ciudad,
        string Clasificacion,
        string Acabados,
        string Serial,
        byte? IdTipo,
        byte? IdLider,
        HashSet<CompraDTO>? compras
 );

    public record CompraDTO(
          short IdCompra,
          byte? Cantidad,
          string Proveedor,
          string Pagado,
          string Fecha,
          short? IdProyecto,
          byte? IdMaterialConstruccion
        );
}