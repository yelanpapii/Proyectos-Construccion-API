using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ProyectosConstruccion.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        private readonly ILogger<LogFilter> _logger;

        public LogFilter(ILogger<LogFilter> log
           )
        {
            _logger = log;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Some Logic
            context.HttpContext.Response.Headers.Add("Filtro-Status", "Success");
            _logger.LogDebug("ANTES DE METODO Y LOGICA APLICADA DEL FILTRO");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var status = context.HttpContext.Response.Headers["Filtro Status"];

            _logger.LogDebug($"DESPUES METODO: {status.ToString()} ");
            base.OnActionExecuted(context);
        }
    }
}