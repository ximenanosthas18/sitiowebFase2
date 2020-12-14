using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROYECTODAS.Models;
using System.Net.Http;

namespace PROYECTODAS.Controllers
{
    public class NoticiaActionController : Controller
    {
        // GET: NoticiaAction
        public ActionResult Index()
        {
            IEnumerable<noticia> noticiaObj = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/NoticiaCrud");

            var consumeapi = hc.GetAsync("NoticiaCrud");
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if(readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<noticia>>();
                displaydata.Wait();

                noticiaObj = displaydata.Result;
            }
            
            return View(noticiaObj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(noticia insertnoticia)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/NoticiaCrud");

            var insertrecord = hc.PostAsJsonAsync<noticia>("NoticiaCrud", insertnoticia);
            insertrecord.Wait();

            var guardardata = insertrecord.Result;
            if(guardardata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Create");
        }

        //ver detalles de una noticia seleccionada
        public ActionResult Detalles(int id)
        {
            NoticiaClass onoticia = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/NoticiaCrud");

            var consumeapi = hc.GetAsync("NoticiaCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if(readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<NoticiaClass>();
                displaydata.Wait();
                onoticia = displaydata.Result;
            }

            return View(onoticia);
        }

        //mostrar pagina de editar
        public ActionResult Editar(int id)
        {
            NoticiaClass onoticia = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/");

            var consumeapi = hc.GetAsync("NoticiaCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<NoticiaClass>();
                displaydata.Wait();
                onoticia = displaydata.Result;
            }

            return View(onoticia);
        }

        //guardar editación
        [HttpPost]
        public ActionResult Editar(NoticiaClass nc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/NoticiaCrud");

            var insertrecord = hc.PutAsJsonAsync<NoticiaClass>("NoticiaCrud", nc);
            insertrecord.Wait();

            var guardardata = insertrecord.Result;
            if (guardardata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Error en actualizar los datos de la noticia";
            }

            return View(nc);

        }

        //borrar noticia
        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/NoticiaCrud");

            var delrecord = hc.DeleteAsync("NoticiaCrud/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if (displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}