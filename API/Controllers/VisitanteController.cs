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
    public class VisitanteController : ApiController
    {
        private readonly VisitanteRepositorio _visitanteRepositorio;

        public VisitanteController()
        {
            _visitanteRepositorio = new VisitanteRepositorio();
        }


        // GET: api/Visitante
        [HttpGet]
        public IEnumerable<Visitante> GetVisitante()
        {
            return _visitanteRepositorio.GetAll();
        }


        // GET: api/Visitante/5
        [HttpGet]
        public Visitante GetVisitante(int id)
        {
            return _visitanteRepositorio.GetById(id);
        }


        // POST: api/Visitante
        [HttpPost()]
        public int Post([FromBody]Visitante v)
        {
            return _visitanteRepositorio.Insert(v);
        }


        // PUT: api/Visitante/5
        [HttpPut()]
        public int Put([FromBody]Visitante v)
        {
            return _visitanteRepositorio.Update(v);
        }

        // DELETE: api/Visitante/5
        public int Delete(int id)
        {
            return _visitanteRepositorio.Delete(id);
        }
    }
}
