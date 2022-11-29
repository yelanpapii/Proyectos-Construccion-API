using ProyectosConstruccion.Filters;
using ProyectosConstruccion.Negocio.Services.Interfaces;
using ProyectosConstruccion.Wrappers;
using System;
using System.Collections.Generic;

namespace ProyectosConstruccion.Helpers
{
    public class PaginationHelper
    {

        /// <summary>
        /// Helper for pagination object
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>PaginationFilter object</returns>
        private static IPaginationFilter SetValue(int pageNumber, int pageSize)
        {
            var pageValues = new PaginationFilter(pageNumber, pageSize);
            return pageValues;
        }

        //Metodo estatico que establecera el valor de las propiedades del PagedResponse
        public static PagedResponse<IEnumerable<T>> CreatePagedResponse<T>(IEnumerable<T> pagedData, IPaginationFilter filter,
            int totalRecords, IUriService uriService, string route)
        {
            var response = new PagedResponse<IEnumerable<T>>(pagedData, filter.PageNumber, filter.PageSize);
            //Calculo para el total de las paginas
            var totalPages = (int)Math.Ceiling((double)(totalRecords / filter.PageSize));

            //Sets the next page value by getting the current request and editing the query paramater
            response.NextPage = filter.PageNumber >= 1 && filter.PageNumber < totalPages
                ? uriService.GetPageUri(SetValue(filter.PageNumber + 1, filter.PageSize), route)
                : null;

            //Previous page
            response.PreviousPage = filter.PageNumber - 1 >= 1 && filter.PageNumber < totalPages
                ? uriService.GetPageUri(SetValue(filter.PageNumber - 1, filter.PageSize), route)
                : null;

            response.FirstPage = uriService.GetPageUri(SetValue(1, filter.PageSize), route);
            response.LastPage = uriService.GetPageUri(SetValue(totalPages, filter.PageSize), route);
            response.TotalRecords = totalRecords;
            response.TotalPage = totalPages;

            return response;
        }
    }
}