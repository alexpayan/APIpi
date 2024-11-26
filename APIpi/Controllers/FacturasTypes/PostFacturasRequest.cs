using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIpi.Controllers.FacturasTypes
{
    public class PostFacturasRequest
    {
        

        [Required]
        public DateOnly Fecha_Factura { get; set; } //verificar si este tipo de dato estaa correcto

        [Required, MaxLength(50)]
        public string Método_Pago { get; set; }

        [Required, MaxLength(50)]
        public string Estado_Pago { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Monto_Total { get; set; }

        [Required]
        public int ID_Evento { get; set; }
    }
}
