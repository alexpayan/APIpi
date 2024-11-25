using APIpi.Controllers.LocacionTypes;
using APIpi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIpi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocacionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<LocacionController> _logger;
        private readonly AppDbContext _context;

        public LocacionController(ILogger<LocacionController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost(Name = "PostLocacion")]
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
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Locacion>> GetById(int id)
        {
            _logger.LogInformation($"Fetching locacion with id [{id}] from the data base...");
            var locacion = await _context.Locaciones.FindAsync(id);
            if (locacion == null)
            {
                _logger.LogWarning($"Locacion with id [{id}] was not found");
                return NotFound();
            }

            _logger.LogInformation($"Found locacion with id [{id}]");
            var response = new Locacion
            {
                ID_Locacion = locacion.ID_Locacion,
                Nombre_Locacion = locacion.Nombre_Locacion,
                Tipo_Locacion = locacion.Tipo_Locacion,
                Capacidad_Maxima = locacion.Capacidad_Maxima,
                Dirección = locacion.Dirección,
                Precio_Base = locacion.Precio_Base
            };

            return Ok(response);
        }

        [HttpGet(Name = "GetAllLocaciones")]
        public async Task<ActionResult<IEnumerable<Locacion>>> GetAll()
        {
            return await _context.Locaciones.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutLocacionResponse>> Put(int id, PutLocacionRequest request)
        {
            var locacionToUpdate = new Locacion
            {
                ID_Locacion = id,
                Nombre_Locacion = request.Nombre_Locacion,
                Tipo_Locacion = request.Tipo_Locacion,
                Capacidad_Maxima = request.Capacidad_Maxima,
                Dirección = request.Dirección,
                Precio_Base = request.Precio_Base
            };

            _context.Locaciones.Update(locacionToUpdate);
            await _context.SaveChangesAsync();

            return Ok(await _context.Locaciones.FindAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var locacion = await _context.Locaciones.FindAsync(id);
            if (locacion == null)
            {
                return NotFound();
            }
            _context.Locaciones.Remove(locacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
