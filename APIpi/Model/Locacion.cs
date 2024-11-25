using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIpi.Model
{
    public class Locacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Locacion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre_Locacion { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoDeLocacion Tipo_Locacion { get; set; }

        [Required]
        public int Capacidad_Maxima { get; set; }

        [MaxLength(255)]
        public string Direcci�n { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio_Base { get; set; }
    }
}
