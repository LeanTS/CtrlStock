using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titulos.Shared.DTO
{
    public class ProductosDTO
    {
        [Required(ErrorMessage = "El Nombre del Producto es Obligatorio")]
        [MaxLength(30, ErrorMessage = "Solo se aceptan hasta 30 caracteres en el Nombre del Producto")]
        public string NombreProd { get; set; }

        [Required(ErrorMessage = "La Descripcion del Producto es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 40 caracteres en la Descripción del Producto")]
        public string Descripcion { get; set; }
    }
}
