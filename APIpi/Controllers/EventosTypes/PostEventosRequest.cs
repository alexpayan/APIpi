using APIpi.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIpi.Controllers.EventosTypes
{
    public class PostEventosRequest
    {
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoDeEvento Tipo_Evento { get; set; }

        [Required]
        public DateOnly Fecha_Evento { get; set; }
        
        [Required]
        public TimeSpan Hora_Evento { get; set; }
        
        [Required]
        public int Número_Personas { get; set; }

        [Required]
        public int ID_Usuario { get; set; }

        [Required]
        public int ID_Locacion { get; set; }

    }
}
