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
    public class ConsumidorController : ApiController
    {
        private readonly ConsumidorRepositorio _consumidorRepositorio;

        public ConsumidorController()
        {
            _consumidorRepositorio = new ConsumidorRepositorio();
        }


        // GET: api/Consumidor
        [HttpGet]
        public IEnumerable<Consumidor> GetConsumidores()
        {
            return _consumidorRepositorio.GetAll();
        }


        // GET: api/Consumidor/5
        [HttpGet]
        public Consumidor GetConsumidor(int id)
        {
            return _consumidorRepositorio.GetById(id);
        }


        // POST: api/Consumidor
        [HttpPost()]
        public int Post([FromBody]Consumidor c)
        {
            return _consumidorRepositorio.Insert(c);
        }


        // PUT: api/Consumidor/5
        [HttpPut()]
        public int Put([FromBody]Consumidor c)
        {
            return _consumidorRepositorio.Update(c);
        }

        // DELETE: api/Consumidor/5
        public int Delete(int id)
        {
            return _consumidorRepositorio.Delete(id);
        }
    }
}
