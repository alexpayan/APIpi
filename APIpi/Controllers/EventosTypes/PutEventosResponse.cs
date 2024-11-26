using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APIpi.Model;

namespace APIpi.Controllers.EventosTypes
{
    public class PutEventosResponse
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
        [ForeignKey("usuario")]
        public int ID_Usuario { get; set; }

        [Required]
        [ForeignKey("locacion")]
        public int ID_Locacion { get; set; }

    }
}
