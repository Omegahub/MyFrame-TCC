using Library.Business;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class AvaliacaoCriterioRepositorio : IRepositorio<AvaliacaoCriterio>
    {
        public int Delete(int id)
        {
            return AvaliacaoCriterioBLL.Delete(id);
        }
        public IEnumerable<AvaliacaoCriterio> GetAll()
        {
            return AvaliacaoCriterioBLL.GetAll();
        }

        public AvaliacaoCriterio GetById(int? id)
        {
            return AvaliacaoCriterioBLL.GetById(id.Value);
        }

        public int Insert(AvaliacaoCriterio item)
        {
            return AvaliacaoCriterioBLL.Insert(item);
        }

        public int Update(AvaliacaoCriterio item)
        {
            return AvaliacaoCriterioBLL.Update(item);
        }
    }
}