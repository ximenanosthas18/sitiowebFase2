using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROYECTODAS.Models
{
    public class NoticiaClass
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Cuerpo { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
    }
}