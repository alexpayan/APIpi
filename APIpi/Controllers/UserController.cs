
using APIpi.Controllers.ServiciosAdTypes;
using APIpi.Controllers.UsuarioController;
using APIpi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIpi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserController> _logger;
        private readonly AppDbContext _context;

        public UserController(ILogger<UserController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost(Name = "PostUser")]
        public async Task<ActionResult<PostUserResponse>> Post(PostUserRequest request)
        {
            var usuario = new Usuario
            {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Correo_Electrónico = request.Correo_Electrónico,
                Contraseña = request.Contraseña,
                Teléfono = request.Teléfono,
                Dirección = request.Dirección,
                Tipo = request.Tipo
            };
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            var response = new PostUserResponse
            {
                ID_Usuario = usuario.ID_Usuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo_Electrónico = usuario.Correo_Electrónico,
                Contraseña = usuario.Contraseña,
                Teléfono = usuario.Teléfono,
                Dirección = usuario.Dirección,
                Tipo = usuario.Tipo
            };

            return CreatedAtAction(nameof(GetById), new { id = usuario.ID_Usuario }, usuario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            _logger.LogInformation($"Fetching locacion with id [{id}] from the data base...");
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                _logger.LogWarning($"Locacion with id [{id}] was not found");
                return NotFound();
            }

            _logger.LogInformation($"Found locacion with id [{id}]");
            var response = new Usuario
            {
                ID_Usuario = usuario.ID_Usuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo_Electrónico = usuario.Correo_Electrónico,
                Contraseña = usuario.Contraseña,
                Teléfono = usuario.Teléfono,
                Dirección = usuario.Dirección,
                Tipo = usuario.Tipo
            };

            return Ok(response);
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _context.Usuario.ToListAsync();
            var response = usuarios.Select(usuario => new GetUserResponse
            {
                ID_Usuario = usuario.ID_Usuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo_Electrónico = usuario.Correo_Electrónico,
                Contraseña = usuario.Contraseña,
                Teléfono = usuario.Teléfono,
                Dirección = usuario.Dirección,
                Tipo = usuario.Tipo
            }).ToList();

            return Ok(response);
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutUserResponse>> Put(int id, PutUserRequest request)
        {
            var usuarioToUpdate = new Usuario
            {
                ID_Usuario = id,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Correo_Electrónico = request.Correo_Electrónico,
                Contraseña = request.Contraseña,
                Teléfono = request.Teléfono,
                Dirección = request.Dirección,
                Tipo = request.Tipo
            };

            _context.Usuario.Update(usuarioToUpdate);
            await _context.SaveChangesAsync();

            return Ok(await _context.Usuario.FindAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

