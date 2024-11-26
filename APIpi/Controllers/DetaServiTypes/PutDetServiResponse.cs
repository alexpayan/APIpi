using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIpi.Controllers.DetaServiTypes
{
    public class PutDetServiResponse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Detalles_Servicios { get; set; }

        [Required, MaxLength(255)]
        public string Notas_Adicionales { get; set; }

        [Required]
        public int ID_Servicio { get; set; }

        [Required]
        public int ID_Eventos { get; set; }


    }
}
