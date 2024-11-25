using APIpi.Controllers.LocacionTypes;
using APIpi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIpi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiciosAdController : ControllerBase
    {
        private readonly ILogger<LocacionController> _logger;
        private readonly AppDbContext _context;

        /*[HttpPost(Name = "PostServiciosA")]
        public async Task<ActionResult<PostLocacionResponse>> Post(PostLocacionRequest request)
        {
            var locacion = new Locacion
            {
                Nombre_Locacion = request.Nombre_Locacion,
                Tipo_Locacion = request.Tipo_Locacion,
                Capacidad_Maxima = request.Capacidad_Maxima,
                Dirección = request.Dirección,
                Precio_Base = request.Precio_Base
            };
            _context.Locaciones.Add(locacion);
            await _context.SaveChangesAsync();

            var response = new PostLocacionResponse
            {
                ID_Locacion = locacion.ID_Locacion,
                Nombre_Locacion = locacion.Nombre_Locacion,
                Tipo_Locacion = locacion.Tipo_Locacion,
                Capacidad_Maxima = locacion.Capacidad_Maxima,
                Dirección = locacion.Dirección,
                Precio_Base = locacion.Precio_Base
            };

            return CreatedAtAction(nameof(GetById), new { id = locacion.ID_Locacion }, locacion);
        }*/
    }
}
