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
    public class EventoController : ApiController
    {
        private readonly EventoRepositorio _eventoRepositorio;

        public EventoController()
        {
            _eventoRepositorio = new EventoRepositorio();
        }


        // GET: api/Evento
        [HttpGet]
        public IEnumerable<Evento> GetEvento()
        {
            return _eventoRepositorio.GetAll();
        }


        // GET: api/Evento/5
        [HttpGet]
        public Evento GetEvento(int id)
        {
            return _eventoRepositorio.GetById(id);
        }


        // POST: api/Evento
        [HttpPost()]
        public int Post([FromBody]Evento e)
        {
            return _eventoRepositorio.Insert(e);
        }


        // PUT: api/Evento/5
        [HttpPut()]
        public int Put([FromBody]Evento e)
        {
            return _eventoRepositorio.Update(e);
        }

        // DELETE: api/Evento/5
        public int Delete(int id)
        {
            return _eventoRepositorio.Delete(id);
        }
    }
}
