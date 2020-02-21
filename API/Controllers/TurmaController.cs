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
    public class TurmaController : ApiController
    {
        private readonly TurmaRepositorio _turmaRepositorio;

        public TurmaController()
        {
            _turmaRepositorio = new TurmaRepositorio();
        }


        // GET: api/Turma
        [HttpGet]
        public IEnumerable<Turma> GetTurma()
        {
            return _turmaRepositorio.GetAll();
        }


        // GET: api/Turma/5
        [HttpGet]
        public Turma GetTurma(int id)
        {
            return _turmaRepositorio.GetById(id);
        }


        // POST: api/Turma
        [HttpPost()]
        public int Post([FromBody]Turma t)
        {
            return _turmaRepositorio.Insert(t);
        }


        // PUT: api/Turma/5
        [HttpPut()]
        public int Put([FromBody]Turma t)
        {
            return _turmaRepositorio.Update(t);
        }

        // DELETE: api/Turma/5
        public int Delete(int id)
        {
            return _turmaRepositorio.Delete(id);
        }
    }
}
