using APIpi.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIpi.Controllers.LocacionTypes
{
    public class PutLocacionRequest
    {
        [Required]
        [MaxLength(100)]
        public string Nombre_Locacion { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoDeLocacion Tipo_Locacion { get; set; }

        [Required]
        public int Capacidad_Maxima { get; set; }

        [MaxLength(255)]
        public string Direcci�n { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio_Base { get; set; }
    }
}
