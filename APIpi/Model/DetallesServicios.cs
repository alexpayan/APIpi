using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIpi.Model
{
    public class DetallesServicios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Detalles_Servicios { get; set; }

        [Required]
        [MaxLength(255)]
        public string Notas_Adicionales { get; set; }

        [Required]
        [ForeignKey("servicio")]
        public int ID_Servicio { get; set; }

        [Required]
        [ForeignKey("evento")]
        public int ID_Eventos { get; set; }

        public ServiciosAdicionales servicio { get; set; }

        public Eventos evento { get; set; }
    }
}
