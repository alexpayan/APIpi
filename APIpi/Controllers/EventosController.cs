using APIpi.Controllers.EventosTypes;
using APIpi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIpi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly ILogger<EventosController> _logger;
        private readonly AppDbContext _context;

        public EventosController(ILogger<EventosController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [HttpPost(Name = "PostEventos")]
        public async Task<ActionResult<PostEventosResponse>> Post(PostEventosRequest request)
        {
            var eventos = new Eventos
            {
                Tipo_Evento = request.Tipo_Evento,
                Fecha_Evento = request.Fecha_Evento,
                Hora_Evento = request.Hora_Evento,
                Número_Personas = request.Número_Personas,
                ID_Usuario = request.ID_Usuario,
                ID_Locacion = request.ID_Locacion
            };
            _context.Eventos.Add(eventos);
            await _context.SaveChangesAsync();

            var response = new PostEventosResponse
            {
                ID_Evento = eventos.ID_Evento,
                Tipo_Evento = eventos.Tipo_Evento,
                Fecha_Evento = eventos.Fecha_Evento,
                Hora_Evento = eventos.Hora_Evento,
                Número_Personas = eventos.Número_Personas,
                ID_Usuario = eventos.ID_Usuario,
                ID_Locacion = eventos.ID_Locacion
            };
            return CreatedAtAction(nameof(GetById), new { id = eventos.ID_Evento }, response);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEventoResponse>> GetById(int id)
        {
            var eventos = await _context.Eventos.FindAsync(id);
            if (eventos == null)
            {
                return NotFound();
            }

            var response = new GetEventoResponse
            {
                ID_Evento = eventos.ID_Evento,
                Tipo_Evento = eventos.Tipo_Evento,
                Fecha_Evento = eventos.Fecha_Evento,
                Hora_Evento = eventos.Hora_Evento,
                Número_Personas = eventos.Número_Personas,
                ID_Usuario = eventos.ID_Usuario,
                ID_Locacion = eventos.ID_Locacion
            };

            return Ok(response);
        }
        
        [HttpGet(Name = "GetAllEventos")]
        public async Task<ActionResult<IEnumerable<Eventos>>> GetAll()
        {
            var eventos = await _context.Eventos.Select(evento => new GetEventoResponse
            {
                ID_Evento = evento.ID_Evento,
                Tipo_Evento = evento.Tipo_Evento,
                Fecha_Evento = evento.Fecha_Evento,
                Hora_Evento = evento.Hora_Evento,
                Número_Personas = evento.Número_Personas,
                ID_Usuario = evento.ID_Usuario,
                ID_Locacion = evento.ID_Locacion
            }).ToListAsync();

            return Ok(eventos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutEventosResponse>> Put(int id, PutEventosRequest request)
        {
            var eventoToUpdate = new Eventos
            {
                ID_Evento = id,
                Tipo_Evento = request.Tipo_Evento,
                Fecha_Evento = request.Fecha_Evento,
                Hora_Evento = request.Hora_Evento,
                Número_Personas = request.Número_Personas,
                ID_Usuario = request.ID_Usuario,
                ID_Locacion = request.ID_Locacion,
            };

            _context.Eventos.Update(eventoToUpdate);
            await _context.SaveChangesAsync();

            var updatedEvento = await _context.Eventos.FindAsync(id);

            var response = new PutEventosResponse
            {
                ID_Evento = updatedEvento.ID_Evento,
                Tipo_Evento = updatedEvento.Tipo_Evento,
                Fecha_Evento = updatedEvento.Fecha_Evento,
                Hora_Evento = updatedEvento.Hora_Evento,
                Número_Personas = updatedEvento.Número_Personas,
                ID_Usuario = updatedEvento.ID_Usuario,
                ID_Locacion = updatedEvento.ID_Locacion,
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
