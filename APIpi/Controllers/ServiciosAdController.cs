using APIpi.Controllers.ServiciosAdTypes;
using APIpi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIpi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiciosAdController : ControllerBase
    {
        
        private readonly ILogger<ServiciosAdController> _logger;
        private readonly AppDbContext _context;

        public ServiciosAdController(ILogger<ServiciosAdController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public ServiciosAdController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost(Name = "PostServicioAd")]
        public async Task<ActionResult<PostServiciosAdResponse>> Post(PostServiciosAdRequest request)
        {
            var servicio = new ServiciosAdicionales
            {
                Nombre_Servicio = request.Nombre_Servicio,
                Precio_Servicio = request.Precio_Servicio,
                Descripción = request.Descripción,
                Teléfono = request.Teléfono
            };

            _context.Servicios_Adicionales.Add(servicio);
            await _context.SaveChangesAsync();

            var response = new PostServiciosAdResponse
            {
                ID_Servicio = servicio.ID_Servicio,
                Nombre_Servicio = servicio.Nombre_Servicio,
                Precio_Servicio = servicio.Precio_Servicio,
                Descripción = servicio.Descripción,
                Teléfono = servicio.Teléfono
            };

            return CreatedAtAction(nameof(GetById), new { id = servicio.ID_Servicio }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetServiciosAdResponse>> GetById(int id)
        {
            var servicio = await _context.Servicios_Adicionales.FindAsync(id);

            if (servicio == null)
            {
                return NotFound();
            }

            var response = new GetServiciosAdResponse
            {
                ID_Servicio = servicio.ID_Servicio,
                Nombre_Servicio = servicio.Nombre_Servicio,
                Precio_Servicio = servicio.Precio_Servicio,
                Descripción = servicio.Descripción,
                Teléfono = servicio.Teléfono
            };

            return Ok(response);
        }

        [HttpGet(Name = "GetAllServiciosAd")]
        public async Task<ActionResult<IEnumerable<GetServiciosAdResponse>>> GetAll()
        {
            var servicios = await _context.Servicios_Adicionales.ToListAsync();
            var response = servicios.Select(s => new GetServiciosAdResponse
            {
                ID_Servicio = s.ID_Servicio,
                Nombre_Servicio = s.Nombre_Servicio,
                Precio_Servicio = s.Precio_Servicio,
                Descripción = s.Descripción,
                Teléfono = s.Teléfono
            }).ToList();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutServiciosAdResponse>> Put(int id, PutServiciosAdRequest request)
        {
            var servicioToUpdate = await _context.Servicios_Adicionales.FindAsync(id);

            if (servicioToUpdate == null)
            {
                return NotFound();
            }

            servicioToUpdate.Nombre_Servicio = request.Nombre_Servicio;
            servicioToUpdate.Precio_Servicio = request.Precio_Servicio;
            servicioToUpdate.Descripción = request.Descripción;
            servicioToUpdate.Teléfono = request.Teléfono;

            _context.Servicios_Adicionales.Update(servicioToUpdate);
            await _context.SaveChangesAsync();

            var response = new PutServiciosAdResponse
            {
                ID_Servicio = servicioToUpdate.ID_Servicio,
                Nombre_Servicio = servicioToUpdate.Nombre_Servicio,
                Precio_Servicio = servicioToUpdate.Precio_Servicio,
                Descripción = servicioToUpdate.Descripción,
                Teléfono = servicioToUpdate.Teléfono
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var servicio = await _context.Servicios_Adicionales.FindAsync(id);

            if (servicio == null)
            {
                return NotFound();
            }

            _context.Servicios_Adicionales.Remove(servicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
