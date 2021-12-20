using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanzasPersonales.Models
{
    public class Gasto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Se debe registrar fecha del Monto")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime FechaGasto { get; set; }

        [Required(ErrorMessage = "Es obligatorio una descripción")]
        [Display(Name = "Descripción")]
        [StringLength(50, ErrorMessage = "La descripción debe ser mayor a 1 caracter")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "Es obligatorio un monto")]
        [Display(Name = "Monto")]
        public int Monto { get; set; }

        [Required(ErrorMessage = "Se debe seleccionar una categoría")]
        [Display(Name = "Categoría")]
        public CategoriaGasto Categoria { get; set; }
    }
}
