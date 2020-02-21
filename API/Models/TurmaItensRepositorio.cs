using Library.Business;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class TurmaItensRepositorio : IRepositorio<TurmaItens>
    {
        public int Delete(int id)
        {
            return TurmaItensBLL.Delete(id);
        }

        public IEnumerable<TurmaItens> GetAll()
        {
            return TurmaItensBLL.GetAll();
        }

        public TurmaItens GetById(int? id)
        {
            return TurmaItensBLL.GetById(id.Value);
        }

        public int Insert(TurmaItens item)
        {
            return TurmaItensBLL.Insert(item);
        }

        public int Update(TurmaItens item)
        {
            return TurmaItensBLL.Update(item);
        }
    }
}