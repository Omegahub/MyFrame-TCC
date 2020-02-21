using API.Models;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Library.Business;

namespace API.Controllers
{
    public class AvaliacaoController : ApiController
    {
        private readonly AvaliacaoRepositorio _avaliacaoRepositorio;

        public AvaliacaoController()
        {
            _avaliacaoRepositorio = new AvaliacaoRepositorio();
        }


        // GET: api/Avaliacao
        [HttpGet]
        public IEnumerable<Avaliacao> GetAvaliacao()
        {
            return _avaliacaoRepositorio.GetAll();
        }


        // GET: api/Avaliacao/5
        [HttpGet]
        public Avaliacao GetAvaliacao(int id)
        {
            return _avaliacaoRepositorio.GetById(id);
        }


        // POST: api/Avaliacao
        [HttpPost()]
        public int Post([FromBody]Avaliacao a)
        {
            return _avaliacaoRepositorio.Insert(a);
        }


        // PUT: api/Avaliacao/5
        [HttpPut()]
        public int Put([FromBody]Avaliacao a)
        {
            return _avaliacaoRepositorio.Update(a);
        }

        // DELETE: api/Avaliacao/5
        public int Delete(int id)
        {
            return _avaliacaoRepositorio.Delete(id);
        }
    }
}
