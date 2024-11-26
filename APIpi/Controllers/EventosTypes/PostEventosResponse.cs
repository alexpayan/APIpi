using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using APIpi.Model;

namespace APIpi.Controllers.EventosTypes
{
    public class PostEventosResponse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Evento { get; set; }

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
