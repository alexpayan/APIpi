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
                ID_Locacion = eventos.ID_Locacion,
                usuario = eventos.Usuario,
                locacion = eventos.Locacion
            };
            return CreatedAtAction(nameof(GetById), new { id = eventos.ID_Evento }, response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEventosResponse>> GetById(int id)
        {
            var eventos = await _context.Eventos.FindAsync(id);
            if (eventos == null)
            {
                return NotFound();
            }
            var response = new GetEventosResponse
            {
                ID_Evento = eventos.ID_Evento,
                Tipo_Evento = eventos.Tipo_Evento,
                Fecha_Evento = eventos.Fecha_Evento,
                Hora_Evento = eventos.Hora_Evento,
                Número_Personas = eventos.Número_Personas,
                ID_Usuario = eventos.ID_Usuario,
                ID_Locacion = eventos.ID_Locacion,
                usuario = eventos.Usuario,
                locacion = eventos.Locacion
            };
            return Ok(response);
        }
        [HttpGet(Name = "GetAllEventos")]
        public async Task<ActionResult<IEnumerable<GetEventosResponse>>> GetAll()
        {
            var eventos = await _context.Eventos.ToListAsync();
            var response = eventos.Select(e => new GetEventosResponse
            {
                ID_Evento = e.ID_Evento,
                Tipo_Evento = e.Tipo_Evento,
                Fecha_Evento = e.Fecha_Evento,
                Hora_Evento = e.Hora_Evento,
                Número_Personas = e.Número_Personas,
                ID_Usuario = e.ID_Usuario,
                ID_Locacion =e.ID_Locacion,
                usuario =e.Usuario,
                locacion =e.Locacion
            }).ToList();
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutEventosResponse>> Put(int id, PutEventosRequest request)
        {
            var eventoUptade = await _context.Eventos.FindAsync(id);
            if (eventoUptade == null)
            {
                return NotFound();
            }
            eventoUptade.ID_Evento = request.ID_Evento;
            eventoUptade.Tipo_Evento = request.Tipo_Evento;
            eventoUptade.Fecha_Evento = request.Fecha_Evento;
            eventoUptade.Hora_Evento = request.Hora_Evento;
            eventoUptade.Número_Personas = request.Número_Personas;
            eventoUptade.ID_Usuario = request.ID_Usuario;
            eventoUptade.ID_Locacion = request.ID_Locacion;

            _context.Eventos.Update(eventoUptade);
            await _context.SaveChangesAsync();

            var response = new PutEventosResponse
            {
                ID_Evento = eventoUptade.ID_Evento,
                Tipo_Evento = eventoUptade.Tipo_Evento,
                Fecha_Evento = eventoUptade.Fecha_Evento,
                Hora_Evento = eventoUptade.Hora_Evento,
                Número_Personas = eventoUptade.Número_Personas,
                ID_Usuario = eventoUptade.ID_Usuario,
                ID_Locacion = eventoUptade.ID_Locacion,
                locacion = eventoUptade.Locacion,
                usuario = eventoUptade.Usuario
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
