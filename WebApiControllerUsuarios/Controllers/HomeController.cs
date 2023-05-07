using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiControllerUsuarios.Models;

namespace WebApiControllerUsuarios.Controllers
{
    public class HomeController : Controller
    {
        /*  public ActionResult Index()
          {
              ViewBag.Title = "Home Page";
              return View();  

          }*/
        public ActionResult Index()
        {

            List<Usuarios_tipo> ls = new List<Usuarios_tipo>();
            using (HttpClient clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri("http://localhost:53231/");
                var request = clienteHttp.GetAsync("api/Values").Result;


                if (request.IsSuccessStatusCode)
                {
                    string resultString = request.Content.ReadAsStringAsync().Result;
                    ls = JsonConvert.DeserializeObject<List<Usuarios_tipo>>(resultString);
                    return View(ls);
                }
                TempData["mensaje"] = "Error de comunicación con el apiWeb";

                return View(new List<Usuarios_tipo>());
            }

        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Usuarios_tipo u)
        {
            using (HttpClient clienteHttp = new HttpClient())
            {
                var postTask = clienteHttp.PostAsJsonAsync<Usuarios_tipo>("http://localhost:53231/api/Values", u);

                if (postTask.Result.IsSuccessStatusCode)
                {
                    TempData["mensaje"] = "Se agrego correctamente";
                    return RedirectToAction("Index");
                }
                TempData["mensaje"] = "Error al agrgar usuario con el apiWeb";
                return View();
            }

        }
        public ActionResult Edit(int id)
        {
            Usuarios_tipo usu = new Usuarios_tipo();
            using (HttpClient clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri("http://localhost:53231/");
                var request = clienteHttp.GetAsync("api/Values/" + id).Result;


                if (request.IsSuccessStatusCode)
                {
                    string resultString = request.Content.ReadAsStringAsync().Result;
                    usu = JsonConvert.DeserializeObject<Usuarios_tipo>(resultString);
                    return View(usu);
                }
                TempData["mensaje"] = "Error de comunicación con el apiWeb";

                return RedirectToAction("index");
            }
        }
        [HttpPost]
        public ActionResult Edit(Usuarios_tipo u)
        {
            using (HttpClient clienteHttp = new HttpClient())
            {
                var putTask = clienteHttp.PutAsJsonAsync<Usuarios_tipo>("http://localhost:53231/api/Values", u);

                if (putTask.Result.IsSuccessStatusCode)
                {
                    TempData["mensaje"] = "Se Edito correctamente";
                    return RedirectToAction("Index");
                }
                TempData["mensaje"] = "Error al Editar usuario con el apiWeb";
                return View();
            }

        }
        public ActionResult Delete(int id)
        {
            Usuarios_tipo usu = new Usuarios_tipo();
            using (HttpClient clienteHttp = new HttpClient())
            {
                clienteHttp.BaseAddress = new Uri("http://localhost:53231/");
                var request = clienteHttp.DeleteAsync("api/Values/" + id).Result;

 
                return RedirectToAction("index");
            }
        }
    }
}
