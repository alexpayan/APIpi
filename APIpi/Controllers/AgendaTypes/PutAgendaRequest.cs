using APIpi.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIpi.Controllers.AgendaTypes
{
    public class PutAgendaRequest
    {
        [Required]
        public int ID_Evento { get; set; }

        [Required]
        public DateOnly Fecha_Reserva { get; set; }

        public DateOnly? Fecha_Confirmación { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EstadoDeReserva Estado_Reserva { get; set; }
    }
}
