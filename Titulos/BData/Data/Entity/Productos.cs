using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Titulos.BData.Data.Entity
{
    public class Productos
    {
        [Key][Required]public long ProdId { get; set; }

        [Required(ErrorMessage = "El Nombre del Producto es Obligatorio")]
        [MaxLength(30, ErrorMessage = "Solo se aceptan hasta 30 caracteres en el Nombre del Producto")]
        public string NomProd { get; set; }

        [Required(ErrorMessage = "La Descripción de es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en la Descripción del Producto")]
        public string DescripcionProd { get; set; }

        [Required(ErrorMessage = "La Cantidad del Producto es Obligatorio")]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "El Precio del Producto es Obligatorio")]
        public int Precio { get; set; }


    }
}
