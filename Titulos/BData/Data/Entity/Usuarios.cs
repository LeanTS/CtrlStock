using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titulos.BData.Data.Entity
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El Usuario es Obligatorio")]
        [MaxLength(15, ErrorMessage = "Solo se aceptan hasta 15 caracteres en el Usuario")]
        public string Usuario { get; set; }
        
        [Required(ErrorMessage = "La Contraseña es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en la Contraseña")]
        public string Contraseña { get; set; }
        
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el Apellido")]
        public string Apellido { get; set; }

        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el Cargo")]
        public string Cargo { get; set; }



    }
}
