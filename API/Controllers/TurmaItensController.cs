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
    public class TurmaItensController : ApiController
    {
        private readonly TurmaItensRepositorio _turmaItensRepositorio;

        public TurmaItensController()
        {
            _turmaItensRepositorio = new TurmaItensRepositorio();
        }


        // GET: api/TurmaItens
        [HttpGet]
        public IEnumerable<TurmaItens> GetTurmaItens()
        {
            return _turmaItensRepositorio.GetAll();
        }


        // GET: api/TurmaItens/5
        [HttpGet]
        public TurmaItens GetTurmaItens(int id)
        {
            return _turmaItensRepositorio.GetById(id);
        }


        // POST: api/TurmaItens
        [HttpPost()]
        public int Post([FromBody]TurmaItens ti)
        {
            return _turmaItensRepositorio.Insert(ti);
        }


        // PUT: api/TurmaItens/5
        [HttpPut()]
        public int Put([FromBody]TurmaItens ti)
        {
            return _turmaItensRepositorio.Update(ti);
        }

        // DELETE: api/TurmaItens/5
        public int Delete(int id)
        {
            return _turmaItensRepositorio.Delete(id);
        }
    }
}
