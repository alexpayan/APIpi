using System.ComponentModel.DataAnnotations;

namespace APIpi.Model
{
    public enum TipoDeServicioAd
    {
        Fotografía,
        [Display(Name = "Decoración Básica")]
        Decoración_Básica,
        [Display(Name = "Decoración Premium")]
        Decoración_Premium,
        Catering,
        [Display(Name = "Equipo de Sonido (incluye DJ)")]
        Equipo_de_Sonido_incluye_DJ,
        Mariachi,
        Murga,
        [Display(Name = "Música en Vivo")]
        Música_en_Vivo,
        Animadores,
        Payasos,
        [Display(Name = "Baño Portáti")]
        Baño_Portátil
    }
}
