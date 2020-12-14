using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROYECTODAS.Models;
using System.Net.Http;

namespace PROYECTODAS.Controllers
{
    public class ConsultaActionController : Controller
    {
        // GET: ConsultaAction
        public ActionResult Formulario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Formulario(ConsultaClass consulta)
        {
            if(ModelState.IsValid)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44316/api/ConsultaCrud");

                var insertrec = hc.PostAsJsonAsync<ConsultaClass>("ConsultaCrud", consulta);
                insertrec.Wait();

                var guardarrec = insertrec.Result;
                if (guardarrec.IsSuccessStatusCode)
                {
                    ViewBag.message = "Gracias " + consulta.Nombre + " por tu mensaje, te contactaremos pronto!";
                }

                ModelState.Clear();

            }
            return View();
        }
    }
}