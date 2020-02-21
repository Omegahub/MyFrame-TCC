using Library.Business;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ConsumidorRepositorio : IRepositorio<Consumidor>
    {
        public int Delete(int id)
        {
            return ConsumidorBLL.Delete(id);
        }

        public IEnumerable<Consumidor> GetAll()
        {
            return ConsumidorBLL.GetAll();
        }

        public Consumidor GetById(int? id)
        {
            return ConsumidorBLL.GetById(id.Value);
        }

        public int Insert(Consumidor item)
        {
            return ConsumidorBLL.Insert(item);
        }

        public int Update(Consumidor item)
        {
            return ConsumidorBLL.Update(item);
        }
    }
}