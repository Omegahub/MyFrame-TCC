using Library.Business;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class VisitanteRepositorio : IRepositorio<Visitante>
    {
        public int Delete(int id)
        {
            return VisitanteBLL.Delete(id);
        }

        public IEnumerable<Visitante> GetAll()
        {
            return VisitanteBLL.GetAll();
        }

        public Visitante GetById(int? id)
        {
            return VisitanteBLL.GetById(id.Value);
        }

        public int Insert(Visitante item)
        {
            return VisitanteBLL.Insert(item);
        }

        public int Update(Visitante item)
        {
            return VisitanteBLL.Update(item);
        }
    }
    {
    }
}