using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIpi.Model
{
    public class Eventos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Evento { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tipo_Evento { get; set; }

        [Required]
        public DateOnly Fecha_Evento { get; set; }

        [Required]
        public TimeOnly Hora_Evento { get; set; }

        [Required]
        public int Número_Personas { get; set; }

        [Required]
        public int ID_Usuario { get; set; }

        [ForeignKey("ID_Usuario")]
        public Usuario Usuario { get; set; }

        [Required]
        public int ID_Locacion { get; set; }

        [ForeignKey("ID_Locacion")]
        public Locacion Locacion { get; set; }
    }
}
