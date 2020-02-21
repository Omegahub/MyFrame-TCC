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
    public class ProjetoController : ApiController
    {
        private readonly ProjetoRepositorio _projetoRepositorio;

        public ProjetoController()
        {
            _projetoRepositorio = new ProjetoRepositorio();
        }


        // GET: api/Projeto
        [HttpGet]
        public IEnumerable<Projeto> GetProjeto()
        {
            return _projetoRepositorio.GetAll();
        }


        // GET: api/Projeto/5
        [HttpGet]
        public Projeto GetProjeto(int id)
        {
            return _projetoRepositorio.GetById(id);
        }


        // POST: api/Projeto
        [HttpPost()]
        public int Post([FromBody]Projeto p)
        {
            return _projetoRepositorio.Insert(p);
        }


        // PUT: api/Projeto/5
        [HttpPut()]
        public int Put([FromBody]Projeto p)
        {
            return _projetoRepositorio.Update(p);
        }

        // DELETE: api/Projeto/5
        public int Delete(int id)
        {
            return _projetoRepositorio.Delete(id);
        }
    }
}
