using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

/* Middleware Comunes: CORS Auth, Static Files,Exception, Routing*/

namespace ProyectosConstruccion.Middlewares
{
    public class MyMiddle
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<MyMiddle> _logger;

        public MyMiddle(RequestDelegate request, ILogger<MyMiddle> log)
        {
            _request = request;
            _logger = log;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("Secret-Key"))
            {
                _logger.LogInformation("Requesting Secrets");
            }
            _logger.LogInformation("Solicitud en curso");
            await _request(context);
            _logger.LogInformation("Se esta accediendo a los recursos");
        }
    }
}