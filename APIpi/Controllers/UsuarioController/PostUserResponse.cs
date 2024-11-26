﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APIpi.Model;
using System.Text.Json.Serialization;

namespace APIpi.Controllers.UsuarioController
{
    public class PostUserResponse
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Usuario { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(100)]
        public string Correo_Electrónico { get; set; }

        [Required]
        [MaxLength(255)]
        public string Contraseña { get; set; }

        [MaxLength(255)]
        public string Teléfono { get; set; }

        [MaxLength(255)]
        public string Dirección { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoDeUsuario Tipo { get; set; }
    }
}
