using API.Models;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class GestorController : ApiController
    {
        private readonly GestorRepositorio _gestorRepositorio;

        public GestorController()
        {
            _gestorRepositorio = new GestorRepositorio();
        }


        // GET: api/Gestor
        [HttpGet]
        public IEnumerable<Gestor> GetGestor()
        {
            return _gestorRepositorio.GetAll();
        }


        // GET: api/Gestor/5
        [HttpGet]
        public Gestor GetGestor(int id)
        {
            return _gestorRepositorio.GetById(id);
        }


        // POST: api/Gestor
        [HttpPost()]
        public int Post([FromBody]Gestor g)
        {
            return _gestorRepositorio.Insert(g);
        }


        // PUT: api/Gestor/5
        [HttpPut()]
        public int Put([FromBody]Gestor g)
        {
            return _gestorRepositorio.Update(g);
        }

        // DELETE: api/Gestor/5
        public int Delete(int id)
        {
            return _gestorRepositorio.Delete(id);
        }
    }
}
