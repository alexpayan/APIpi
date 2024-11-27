using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIpi.Model;
using System.Text.Json.Serialization;

namespace APIpi.Controllers.FacturasTypes
{
    public class PostFacturasRequest
    {
        

        [Required]
        public DateOnly Fecha_Factura { get; set; } //verificar si este tipo de dato estaa correcto

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MetodoDePago Método_Pago { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EstadoDePago Estado_Pago { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Monto_Total { get; set; }

        [Required]
        public int ID_Evento { get; set; }
    }
}
