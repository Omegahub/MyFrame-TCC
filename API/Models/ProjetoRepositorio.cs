using Library.Business;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ProjetoRepositorio : IRepositorio<Projeto>
    {
        public int Delete(int id)
        {
            return ProjetoBLL.Delete(id);
        }

        public IEnumerable<Projeto> GetAll()
        {
            return ProjetoBLL.GetAll();
        }

        public Projeto GetById(int? id)
        {
            return ProjetoBLL.GetById(id.Value);
        }

        public int Insert(Projeto item)
        {
            return ProjetoBLL.Insert(item);
        }

        public int Update(Projeto item)
        {
            return ProjetoBLL.Update(item);
        }
    }
}