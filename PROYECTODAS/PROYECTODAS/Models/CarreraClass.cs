using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROYECTODAS.Models
{
    public class CarreraClass
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Campus { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public int Duracion { get; set; }
    }
}