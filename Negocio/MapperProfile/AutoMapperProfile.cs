using AutoMapper;
using ProyectosConstruccion.Negocio.DtoModels;
using ProyectosConstruccion.Persistencia.Models;

namespace ProyectosConstruccion.Negocio.MapperProfile
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProyectoDTO, Proyecto>().ReverseMap();
            CreateMap<CompraDTO, Compra>().ReverseMap();
        }
    }
}
