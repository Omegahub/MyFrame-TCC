using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class AvaliacaoCriterioBLL
    {
        public static int Insert(AvaliacaoCriterio ac)
        {
            return AvaliacaoCriterioDAL.Insert(ac);
        }

        public static int Update(AvaliacaoCriterio ac)
        {
            return AvaliacaoCriterioDAL.Update(ac);
        }
        public static int Delete(int idCriterioAvaliacao)
        {
            return AvaliacaoCriterioDAL.Delete(idCriterioAvaliacao);
        }

        public static List<AvaliacaoCriterio> GetAll()
        {
            return AvaliacaoCriterioDAL.GetAll();
        }

        public static AvaliacaoCriterio GetById(int idCriterioAvaliacao)
        {
            return AvaliacaoCriterioDAL.GetById(idCriterioAvaliacao);
        }
    }
}
