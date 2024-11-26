using System.ComponentModel.DataAnnotations;

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
        [MaxLength(50)]
        public string Estado_Reserva { get; set; }
    }
}
