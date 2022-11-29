using ProyectosConstruccion.Negocio.Services.Interfaces;

namespace ProyectosConstruccion.Filters
{
    //Use this in the controller FromQuery Parameters to validate filters
    public class PaginationFilter : IPaginationFilter
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public PaginationFilter()
        {
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }

}