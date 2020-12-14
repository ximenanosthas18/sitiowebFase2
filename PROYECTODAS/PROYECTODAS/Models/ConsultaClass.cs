using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROYECTODAS.Models
{
    public class ConsultaClass
    {
        [Required(ErrorMessage = "Por favor introduzca su nombre")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor introduzca su apellido")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su numero de telefono")]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-.●]?([0-9]{4})$",
            ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Por favor ingrese su correo")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Correo no es valido")]
        public string Correo { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Debe de introducir una consulta")]
        [Display(Name = "Consulta")]
        public string Mensaje { get; set; }
    }
}