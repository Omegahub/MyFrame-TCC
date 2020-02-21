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
    public class AvaliacaoCriterioController : ApiController
    {
        private readonly AvaliacaoCriterioRepositorio _avaliacaoCriterioRepositorio;

        public AvaliacaoCriterioController()
        {
            _avaliacaoCriterioRepositorio = new AvaliacaoCriterioRepositorio();
        }


        // GET: api/AvaliacaoCriterio
        [HttpGet]
        public IEnumerable<AvaliacaoCriterio> GetAvaliacaoCriterio()
        {
            return _avaliacaoCriterioRepositorio.GetAll();
        }


        // GET: api/AvaliacaoCriterio/5
        [HttpGet]
        public AvaliacaoCriterio GetAvaliacaoCriterio(int id)
        {
            return _avaliacaoCriterioRepositorio.GetById(id);
        }


        // POST: api/AvaliacaoCriterio
        [HttpPost()]
        public int Post([FromBody]AvaliacaoCriterio ac)
        {
            return _avaliacaoCriterioRepositorio.Insert(ac);
        }


        // PUT: api/AvaliacaoCriterio/5
        [HttpPut()]
        public int Put([FromBody]AvaliacaoCriterio ac)
        {
            return _avaliacaoCriterioRepositorio.Update(ac);
        }

        // DELETE: api/AvaliacaoCriterio/5
        public int Delete(int id)
        {
            return _avaliacaoCriterioRepositorio.Delete(id);
        }
    }
}
