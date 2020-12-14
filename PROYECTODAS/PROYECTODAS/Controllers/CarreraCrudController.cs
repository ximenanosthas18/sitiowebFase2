using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PROYECTODAS.Models;

namespace PROYECTODAS.Controllers
{
    public class CarreraCrudController : ApiController
    {
        private uniwebsiteEntities uniwebsite = new uniwebsiteEntities();

        //metodo GET para enlistar todas las carreras
        public IHttpActionResult Getcarrera()
        {
            var results = uniwebsite.carreras.ToList();
            return Ok(results);
        }

        //crear una carrera POST
        [HttpPost]
        public IHttpActionResult Insertcarrera(carrera insertcarrera)
        {
            uniwebsite.carreras.Add(insertcarrera);
            uniwebsite.SaveChanges();
            return Ok();
        }

        //mostrar detalles de una carrera seleccionada
        public IHttpActionResult GetCarreraId(int id)
        {
            CarreraClass carreraDetalles = null;
            carreraDetalles = uniwebsite.carreras.Where(x => x.id == id).Select(x => new CarreraClass()
            {
                Id = x.id,
                Nombre = x.nombre,
                Campus = x.campus,
                Tipo = x.tipo,
                Duracion = x.duracion,
            }).FirstOrDefault<CarreraClass>();

            if (carreraDetalles == null)
            {
                return NotFound();
            }

            return Ok(carreraDetalles);
        }

        //actualizar datos de una carrera. cc = carrera class
        public IHttpActionResult Put(CarreraClass cc)
        {
            var actualizacion = uniwebsite.carreras.Where(x => x.id == cc.Id).FirstOrDefault<carrera>();
            if (actualizacion != null)
            {
                actualizacion.id = cc.Id;
                actualizacion.nombre = cc.Nombre;
                actualizacion.campus = cc.Campus;
                actualizacion.tipo = cc.Tipo;
                actualizacion.duracion = cc.Duracion;
                uniwebsite.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        //metodo DELETE para eliminar una carrera de la lista
        public IHttpActionResult Delete(int id)
        {
            var carreradel = uniwebsite.carreras.Where(x => x.id == id).FirstOrDefault();
            uniwebsite.Entry(carreradel).State = System.Data.Entity.EntityState.Deleted;
            uniwebsite.SaveChanges();
            return Ok();
        }

        //hacer busquedas de carreras segun el campus
        public IHttpActionResult Getcarreracampus(string search)
        {
            var result = uniwebsite.carreras.Where(x => x.campus.StartsWith(search) || search == null).ToList();
            return Ok(result);
        }
    }
}
