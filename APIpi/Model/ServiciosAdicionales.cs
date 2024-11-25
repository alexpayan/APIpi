using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIpi.Model
{
    public class ServiciosAdicionales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Servicio { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre_Servicio { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio_Servicio { get; set; }

        [MaxLength(255)]
        public string Descripción { get; set; }

        [MaxLength(15)]
        public string Teléfono { get; set; }
    }
}
