using APIpi.Controllers.DetaServiTypes;
using APIpi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIpi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetallesServiciosController : ControllerBase
    {
        private readonly ILogger<DetallesServiciosController> _logger;
        private readonly AppDbContext _context;

        public DetallesServiciosController(ILogger<DetallesServiciosController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost(Name = "PostDetallesServicios")]
        public async Task<ActionResult<PostDetServiResponse>> Post(PostDetServiRequest request)
        {
            var servicio = new DetallesServicios
            {
              Notas_Adicionales = request.Notas_Adicionales,
              ID_Evento = request.ID_Eventos,
              ID_Servicio = request.ID_Servicio
            };
            _context.Detalles_Servicios.Add(servicio);
            await _context.SaveChangesAsync();

            var response = new PostDetServiResponse
            {
                ID_Detalles_Servicios =servicio.ID_Detalles_Servicios,
                Notas_Adicionales = servicio.Notas_Adicionales,
                ID_Eventos = servicio.ID_Evento,
                ID_Servicio = servicio.ID_Servicio
            };
            return CreatedAtAction(nameof(GetById), new { id = servicio.ID_Detalles_Servicios }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetDetServiResponse>> GetById(int id)
        {
            var servicio = await _context.Detalles_Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            var response = new GetDetServiResponse
            {
                ID_Detalles_Servicios = servicio.ID_Detalles_Servicios,
                Notas_Adicionales = servicio.Notas_Adicionales,
                ID_Eventos = servicio.ID_Evento,
                ID_Servicio = servicio.ID_Servicio
            };

            return Ok(response);
        }

        [HttpGet(Name = "GetAllDetallesServicios")]
        public async Task<ActionResult<IEnumerable<DetallesServicios>>> GetAll()
        {
            var servicios = await _context.Detalles_Servicios.Select(servicio => new GetDetServiResponse
            {
                ID_Detalles_Servicios = servicio.ID_Detalles_Servicios,
                Notas_Adicionales = servicio.Notas_Adicionales,
                ID_Eventos = servicio.ID_Evento,
                ID_Servicio = servicio.ID_Servicio
            }).ToListAsync();

            return Ok(servicios);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutDetServiResponse>> Put(int id, PutDetServiRequest request)
        {
            var serviciosToUpdate = new DetallesServicios
            {
                ID_Detalles_Servicios = id,
                Notas_Adicionales = request.Notas_Adicionales,
                ID_Evento = request.ID_Eventos,
                ID_Servicio = request.ID_Servicio
            };

            _context.Detalles_Servicios.Update(serviciosToUpdate);
            await _context.SaveChangesAsync();

            var updatedDetServi = await _context.Detalles_Servicios.FindAsync(id);

            var response = new PutDetServiResponse
            {
                ID_Detalles_Servicios = id,
                Notas_Adicionales = updatedDetServi.Notas_Adicionales,
                ID_Eventos = updatedDetServi.ID_Evento,
                ID_Servicio = updatedDetServi.ID_Servicio
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var servicio = await _context.Detalles_Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }
            _context.Detalles_Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
