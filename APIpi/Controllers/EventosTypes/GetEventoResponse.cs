using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIpi.Model;
using System.Text.Json.Serialization;

namespace APIpi.Controllers.EventosTypes
{
    public class GetEventoResponse
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
