using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIpi.Controllers.DetaServiTypes
{
    public class PutDetServiRequest
    {

        [Required, MaxLength(255)]
        public string Notas_Adicionales { get; set; }

        [Required]
        public int ID_Servicio { get; set; }

        [Required]
        public int ID_Eventos { get; set; }
        
    }
}
