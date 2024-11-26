using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APIpi.Model;

namespace APIpi.Controllers.EventosTypes
{
    public class PostEventosResponse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Evento { get; set; }
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

        [ForeignKey("usuario")]
        public Usuario usuario { get; set; }
        [ForeignKey("locacion")]
        public Locacion locacion { get; set; }
    }
}
