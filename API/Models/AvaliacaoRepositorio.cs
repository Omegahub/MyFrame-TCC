using Library.Business;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class AvaliacaoRepositorio : IRepositorio<Avaliacao>
    {
        public int Delete(int id)
        {
            return AvaliacaoBLL.Delete(id);
        }
        public IEnumerable<Avaliacao> GetAll()
        {
            return AvaliacaoBLL.GetAll();
        }

        public Avaliacao GetById(int? id)
        {
            return AvaliacaoBLL.GetById(id.Value);
        }

        public int Insert(Avaliacao item)
        {
            return AvaliacaoBLL.Insert(item);
        }

        public int Update(Avaliacao item)
        {
            return AvaliacaoBLL.Update(item);
        }
    }
}