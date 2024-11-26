using APIpi.Controllers.FacturasTypes;
using APIpi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIpi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturasController : ControllerBase
    {
        private readonly ILogger<FacturasController> _logger;
        private readonly AppDbContext _context;

        public FacturasController(ILogger<FacturasController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost(Name = "PostFactura")]
        public async Task<ActionResult<PostFacturasResponse>> Post(PostFacturasRequest request)
        {
            var factura = new Facturas
            {
                ID_Evento = request.ID_Evento,
                Fecha_Factura = request.Fecha_Factura,
                Monto_Total = request.Monto_Total,
                Método_Pago = request.Método_Pago,
                Estado_Pago = request.Estado_Pago,
            };
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();

            var response = new PostFacturasResponse
            {
                ID_Factura = factura.ID_Factura,
                ID_Evento = factura.ID_Evento,
                Fecha_Factura = factura.Fecha_Factura,
                Monto_Total = factura.Monto_Total,
                Método_Pago = factura.Método_Pago,
                Estado_Pago = factura.Estado_Pago,
            };
            return CreatedAtAction(nameof(GetById), new { id = factura.ID_Factura }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetFacturasResponse>> GetById(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            var response = new GetFacturasResponse
            {
                ID_Factura = factura.ID_Factura,
                ID_Evento = factura.ID_Evento,
                Fecha_Factura = factura.Fecha_Factura,
                Monto_Total = factura.Monto_Total,
                Método_Pago = factura.Método_Pago,
                Estado_Pago = factura.Estado_Pago,
            };

            return Ok(response);
        }

        [HttpGet(Name = "GetAllFacturas")]
        public async Task<ActionResult<IEnumerable<Facturas>>> GetAll()
        {
            var facturas = await _context.Facturas.Select(factura => new GetFacturasResponse
            {
                ID_Factura = factura.ID_Factura,
                ID_Evento = factura.ID_Evento,
                Fecha_Factura = factura.Fecha_Factura,
                Monto_Total = factura.Monto_Total,
                Método_Pago = factura.Método_Pago,
                Estado_Pago = factura.Estado_Pago
                    
            }).ToListAsync();

            return Ok(facturas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PutFacturasResponse>> Put(int id, PutFacturasRequest request)
        {
            var facturaToUpdate = new Facturas
            {
                ID_Factura = id,
                ID_Evento = request.ID_Evento,
                Fecha_Factura = request.Fecha_Factura,
                Monto_Total = request.Monto_Total,
                Método_Pago = request.Método_Pago,
                Estado_Pago = request.Estado_Pago,
            };

            _context.Facturas.Update(facturaToUpdate);
            await _context.SaveChangesAsync();

            var updatedAgenda = await _context.Facturas.FindAsync(id);

            var response = new PutFacturasResponse
            {
                ID_Factura = facturaToUpdate.ID_Factura,
                ID_Evento = facturaToUpdate.ID_Evento,
                Fecha_Factura = facturaToUpdate.Fecha_Factura,
                Monto_Total = facturaToUpdate.Monto_Total,
                Método_Pago = facturaToUpdate.Método_Pago,
                Estado_Pago = facturaToUpdate.Estado_Pago
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
