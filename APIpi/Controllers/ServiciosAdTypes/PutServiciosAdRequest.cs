using APIpi.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIpi.Controllers.ServiciosAdTypes
{
    public class PutServiciosAdRequest
    {
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoDeServicioAd Nombre_Servicio { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio_Servicio { get; set; }

        [MaxLength(255)]
        public string Descripción { get; set; }

        [MaxLength(15)]
        public string Teléfono { get; set; }
    }
}
