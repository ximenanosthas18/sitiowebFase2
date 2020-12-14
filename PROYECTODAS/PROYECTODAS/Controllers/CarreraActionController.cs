using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROYECTODAS.Models;
using System.Net.Http;

namespace PROYECTODAS.Controllers
{
    public class CarreraActionController : Controller
    {
        // GET: CarreraAction
        public ActionResult ListadoCarreras(string search)
        {
            IEnumerable<carrera> ocarrera = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/CarreraCrud");

            var consumeapi = hc.GetAsync("CarreraCrud?search=" + search);
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<carrera>>();
                displaydata.Wait();

                ocarrera = displaydata.Result;
            }
            return View(ocarrera);
        }

        //mostrar pagina CREATE donde se crea una nueva carrera
        public ActionResult Create()
        {
            return View();
        }

        //crear una carrera en pagina CREATE
        [HttpPost]
        public ActionResult Create(carrera insertcarrera)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/CarreraCrud");

            var insertrecord = hc.PostAsJsonAsync<carrera>("CarreraCrud", insertcarrera);
            insertrecord.Wait();

            var guardardata = insertrecord.Result;
            if (guardardata.IsSuccessStatusCode)
            {
                return RedirectToAction("ListadoCarreras");
            }

            return View("Create");
        }

        //ver detalles de una carrera seleccionada
        public ActionResult Detalles(int id)
        {
            CarreraClass ocarrera = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/");

            var consumeapi = hc.GetAsync("CarreraCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<CarreraClass>();
                displaydata.Wait();
                ocarrera = displaydata.Result;
            }

            return View(ocarrera);
        }

        //mostrar datos actuales de la carrera en pagina de editar
        public ActionResult Editar(int id)
        {
            CarreraClass ocarrera = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/");

            var consumeapi = hc.GetAsync("CarreraCrud?id=" + id.ToString());
            consumeapi.Wait();

            var readdata = consumeapi.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<CarreraClass>();
                displaydata.Wait();
                ocarrera = displaydata.Result;
            }

            return View(ocarrera);
        }

        //editar y guardar los nuevos datos de carrera
        [HttpPost]
        public ActionResult Editar(CarreraClass cc)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/CarreraCrud");

            var insertrecord = hc.PutAsJsonAsync<CarreraClass>("CarreraCrud", cc);
            insertrecord.Wait();

            var guardardata = insertrecord.Result;
            if (guardardata.IsSuccessStatusCode)
            {
                return RedirectToAction("ListadoCarreras");
            }
            else
            {
                ViewBag.message = "Error en actualizar los datos de la carrera";
            }

            return View(cc);
        }

        //borrar una carrera de la lista
        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44316/api/CarreraCrud");

            var delrecord = hc.DeleteAsync("CarreraCrud/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if (displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("ListadoCarreras");
            }

            return View("ListadoCarreras");
        }

    }
}