﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIpi.Model
{
    public class Facturas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Factura { get; set; }

        [Required]
       
        public DateOnly Fecha_Factura { get; set; } //verificar si este tipo de dato estaa correcto

        [Required]
        [MaxLength(50)]
        public string Método_Pago { get; set; }

        [Required]
        [MaxLength(50)]
        public string Estado_Pago { get; set; }

        [Required]
        [ForeignKey("evento")]
        public int ID_Evento { get; set; }

        public Eventos evento { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Monto_Total { get; set; }
    }
}
