using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillDomTestFront.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} del articulo debe contener al menos entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El contenido es obligatorio")]
        [StringLength(100, ErrorMessage = "El {0} del contenido del articulo debe contener al menos entre {2} y {1} caracteres", MinimumLength = 5)]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Required(ErrorMessage = "La ruta de la imagen es obligatoria")]
        [Display(Name = "Imagen")]
        public string Image { get; set; }
    }
}
