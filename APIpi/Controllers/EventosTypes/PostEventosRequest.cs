using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIpi.Controllers.EventosTypes
{
    public class PostEventosRequest
    {
        [Required, MaxLength(50)]
        public string Tipo_Evento { get; set; }
        [Required]
        public DateOnly Fecha_Evento { get; set; }
        [Required]
        public TimeOnly Hora_Evento { get; set; }
        [Required]
        public int Número_Personas { get; set; }
        [Required]
        public int ID_Usuario { get; set; }
        [Required]
        public int ID_Locacion { get; set; }
    }
}
