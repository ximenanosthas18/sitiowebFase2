using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PROYECTODAS.Models;

namespace PROYECTODAS.Controllers
{
    public class ConsultaCrudController : ApiController
    {
        private uniwebsiteEntities uniwebsite = new uniwebsiteEntities();
        public IHttpActionResult Consultaform(ConsultaClass consulta)
        {
            uniwebsite.consultas.Add(new consulta()
            {
                nombre = consulta.Nombre,
                apellido = consulta.Apellido,
                telefono = consulta.Telefono,
                correo = consulta.Correo,
                mensaje = consulta.Mensaje,
            });
            uniwebsite.SaveChanges();
            return Ok();

        }
    }
}
