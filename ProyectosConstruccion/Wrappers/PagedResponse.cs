
using ProyectosConstruccion.Application.Models;
using System;

namespace ProyectosConstruccion.Wrappers
{
    //The response for paginated records
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public int TotalPage { get; set; }
        public int TotalRecords { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize) : base(data)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }
    }
}
