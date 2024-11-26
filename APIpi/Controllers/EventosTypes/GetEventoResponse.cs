using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIpi.Controllers.EventosTypes
{
    public class GetEventoResponse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Evento { get; set; }

        [Required, MaxLength(50)]
        public string Tipo_Evento { get; set; }

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
