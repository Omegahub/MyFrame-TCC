using Library.Business;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class GestorRepositorio : IRepositorio<Gestor>
    {
        public int Delete(int id)
        {
            return GestorBLL.Delete(id);
        }

        public IEnumerable<Gestor> GetAll()
        {
            return GestorBLL.GetAll();
        }

        public Gestor GetById(int? id)
        {
            return GestorBLL.GetById(id.Value);
        }

        public int Insert(Gestor item)
        {
            return GestorBLL.Insert(item);
        }

        public int Update(Gestor item)
        {
            return GestorBLL.Update(item);
        }
    }
}