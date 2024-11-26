using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIpi.Model
{
    public class Agenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Agenda { get; set; }

        [Required]
        [ForeignKey("evento")]
        public int ID_Evento { get; set; }

        [Required]
        public DateOnly Fecha_Reserva { get; set; }

        public DateOnly? Fecha_Confirmación { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EstadoDeReserva Estado_Reserva { get; set; }

        public Eventos evento { get; set; }
    }
}
