using Library.Business;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class TurmaRepositorio : IRepositorio<Turma>
    {
        public int Delete(int id)
        {
            return TurmaBLL.Delete(id);
        }

        public IEnumerable<Turma> GetAll()
        {
            return TurmaBLL.GetAll();
        }

        public Turma GetById(int? id)
        {
            return TurmaBLL.GetById(id.Value);
        }

        public int Insert(Turma item)
        {
            return TurmaBLL.Insert(item);
        }

        public int Update(Turma item)
        {
            return TurmaBLL.Update(item);
        }
    }
}