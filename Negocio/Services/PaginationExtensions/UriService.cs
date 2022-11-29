using Microsoft.AspNetCore.WebUtilities;
using ProyectosConstruccion.Negocio.Services.Interfaces;
using System;

namespace ProyectosConstruccion.Negocio.Services.PaginationExtensions
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPageUri(IPaginationFilter filter, string route)
        {
            var _endpointUri = new Uri(string.Concat(_baseUri, route));
            //Add the values of the query parameters from the filter
            var modifiedUri = QueryHelpers.AddQueryString(_endpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());

            return new Uri(modifiedUri);
        }
    }
}