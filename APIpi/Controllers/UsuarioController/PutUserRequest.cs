using APIpi.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIpi.Controllers.UsuarioController
{
    public class PutUserRequest
    {
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(100)]
        public string Correo_Electr�nico { get; set; }

        [Required]
        [MaxLength(255)]
        public string Contrase�a { get; set; }

        [MaxLength(255)]
        public string Tel�fono { get; set; }

        [MaxLength(255)]
        public string Direcci�n { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoDeUsuario Tipo { get; set; }
    }
}
