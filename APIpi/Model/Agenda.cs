using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [MaxLength(50)]
        public string Estado_Reserva { get; set; }

        public Eventos evento { get; set; }
    }
}
