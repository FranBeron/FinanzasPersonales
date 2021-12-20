using System;
using System.ComponentModel.DataAnnotations;

namespace FinanzasPersonales.Models
{
    public class Ingreso
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Se debe registrar fecha del Igreso")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Es obligatorio una descripción")]
        [Display(Name = "Descripción")]
        [StringLength(50, ErrorMessage = "La descripción debe ser mayor a 1 caracter")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "Es obligatorio un monto")]
        [Display(Name = "Monto")]
        public int Monto { get; set; }

        [Required(ErrorMessage = "Se debe seleccionar una categoría")]
        [Display(Name = "Categoría")]
        public CategoriaIngreso Categoria { get; set; }
    }
}
