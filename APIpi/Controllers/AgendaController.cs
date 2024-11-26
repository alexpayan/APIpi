using APIpi.Controllers.AgendaTypes;
using APIpi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace APIpi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendaController : ControllerBase
    {
        private readonly ILogger<AgendaController> _logger;
        private readonly AppDbContext _context;

        public AgendaController(ILogger<AgendaController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost(Name = "PostAgenda")]
        public async Task<ActionResult<PostAgendaResponse>> Post(PostAgendaRequest request)
        {
            var agenda = new Agenda
            {
                ID_Evento = request.ID_Evento,
                Fecha_Reserva = request.Fecha_Reserva,
                Fecha_Confirmación = request.Fecha_Confirmación,
                Estado_Reserva = request.Estado_Reserva
            };
            _context.Agendas.Add(agenda);
            await _context.SaveChangesAsync();

            var response = new PostAgendaResponse
            {
                ID_Agenda = agenda.ID_Agenda,
                ID_Evento = agenda.ID_Evento,
                Fecha_Reserva = agenda.Fecha_Reserva,
                Fecha_Confirmación = agenda.Fecha_Confirmación,
                Estado_Reserva = agenda.Estado_Reserva
            };
            return CreatedAtAction(nameof(GetById), new { id = agenda.ID_Agenda }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAgendaResponse>> GetById(int id)
        {
            var agenda = await _context.Agendas.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }

            var response = new GetAgendaResponse
            {
                ID_Agenda = agenda.ID_Agenda,
                ID_Evento = agenda.ID_Evento,
                Fecha_Reserva = agenda.Fecha_Reserva,
                Fecha_Confirmación = agenda.Fecha_Confirmación,
                Estado_Reserva = agenda.Estado_Reserva
            };

            return Ok(response);
        }

        [HttpGet(Name = "GetAllAgendas")]
        public async Task<ActionResult<IEnumerable<Agenda>>> GetAll()
        {
            var agendas = await _context.Agendas.Select(agenda => new GetAgendaResponse
            {
                ID_Agenda = agenda.ID_Agenda,
                ID_Evento = agenda.ID_Evento,
                Fecha_Reserva = agenda.Fecha_Reserva,
                Fecha_Confirmación = agenda.Fecha_Confirmación,
                Estado_Reserva = agenda.Estado_Reserva
            }).ToListAsync();

            return Ok(agendas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutAgendaResponse>> Put(int id, PutAgendaRequest request)
        {
            var agendaToUpdate = new Agenda
            {
                ID_Agenda = id,
                ID_Evento = request.ID_Evento,
                Fecha_Reserva = request.Fecha_Reserva,
                Fecha_Confirmación = request.Fecha_Confirmación,
                Estado_Reserva = request.Estado_Reserva,
            };

            _context.Agendas.Update(agendaToUpdate);
            await _context.SaveChangesAsync();

            var updatedAgenda = await _context.Agendas.FindAsync(id);

            var response = new PutAgendaResponse
            {
                ID_Agenda = updatedAgenda.ID_Agenda,
                ID_Evento = updatedAgenda.ID_Evento,
                Fecha_Reserva = updatedAgenda.Fecha_Reserva,
                Fecha_Confirmación = updatedAgenda.Fecha_Confirmación,
                Estado_Reserva = updatedAgenda.Estado_Reserva,
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var agenda = await _context.Agendas.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }
            _context.Agendas.Remove(agenda);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
