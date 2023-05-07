using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiControllerUsuarios.Models;

namespace WebApiControllerUsuarios.Controllers
{
    public class ValuesController : ApiController
    {
       G18Entities db = new G18Entities();
        // GET api/values
        public List<Usuarios_tipo> Get()
        {
            List<Usuarios_tipo> ls = db.Usuarios_tipo.ToList();
            db.Dispose();
            return ls;
        }

        // GET api/values/5
        [HttpGet]
        public Usuarios_tipo ObtenerPorID(int id)
        {
            Usuarios_tipo usu = db.Usuarios_tipo.Find(id);
            db.Dispose();
            return usu;
        }

        // POST api/values
        [HttpPost]
        public void Agregar(Usuarios_tipo usu)
        {
            db.Usuarios_tipo.Add(usu);
            db.SaveChanges();

            db.Dispose();
        }

        // PUT api/values/5
        public void Put(Usuarios_tipo usu)
        {
            Usuarios_tipo based = db.Usuarios_tipo.Find(usu.Id);
            based.Nombre = usu.Nombre;
            based.ApPaterno = usu.ApPaterno;
            based.ApMaterno = usu.ApMaterno;

            db.SaveChanges();
            db.Dispose();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {

            Usuarios_tipo based = db.Usuarios_tipo.Find(id);
            db.Usuarios_tipo.Remove(based);
            db.SaveChanges();
            db.Dispose();
        }
    }
}
