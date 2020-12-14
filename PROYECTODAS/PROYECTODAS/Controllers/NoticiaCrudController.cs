using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PROYECTODAS.Models;

namespace PROYECTODAS.Controllers
{
    public class NoticiaCrudController : ApiController
    {
        private uniwebsiteEntities uniwebsite = new uniwebsiteEntities();
        public IHttpActionResult Getnoticia()
        {
            var resultados = uniwebsite.noticias.ToList();
            return Ok(resultados);
        }

        [HttpPost]
        public IHttpActionResult Insertnoticia(noticia insertnoticia)
        {
            uniwebsite.noticias.Add(insertnoticia);
            uniwebsite.SaveChanges();
            return Ok();
        }

        //mostrar detalles de una noticia
        public IHttpActionResult GetNoticiaId(int id)
        {
            NoticiaClass noticiaDetalles = null;
            noticiaDetalles = uniwebsite.noticias.Where(x => x.id == id).Select(x => new NoticiaClass()
            {
                Id = x.id,
                Titulo = x.titulo,
                Cuerpo = x.cuerpo,
                Fecha = x.fecha,
            }).FirstOrDefault<NoticiaClass>();

            if(noticiaDetalles == null)
            {
                return NotFound();
            }

            return Ok(noticiaDetalles);
        }

        //actualizar datos de una noticia. nc = noticia class
        public IHttpActionResult Put(NoticiaClass nc)
        {
            var actualizacion = uniwebsite.noticias.Where(x => x.id == nc.Id).FirstOrDefault<noticia>();
            if(actualizacion != null)
            {
                actualizacion.id = nc.Id;
                actualizacion.titulo = nc.Titulo;
                actualizacion.cuerpo = nc.Cuerpo;
                actualizacion.fecha = nc.Fecha;
                uniwebsite.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();

        }

        //metodo DELETE para borrar noticia
        public IHttpActionResult Delete(int id)
        {
            var noticiadel = uniwebsite.noticias.Where(x => x.id == id).FirstOrDefault();
            uniwebsite.Entry(noticiadel).State = System.Data.Entity.EntityState.Deleted;
            uniwebsite.SaveChanges();
            return Ok();
        }


    }
}


