using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class AvaliacaoBLL
    {
        public static int Insert(Avaliacao a)
        {
            return AvaliacaoDAL.Insert(a);
        }

        public static int Update(Avaliacao a)
        {
            return AvaliacaoDAL.Update(a);
        }
        public static int Delete(int idAvaliacao)
        {
            return ConsumidorDAL.Delete(idAvaliacao);
        }

        public static List<Avaliacao> GetAll()
        {
            return AvaliacaoDAL.GetAll();
        }

        public static Avaliacao GetById(int idAvaliacao)
        {
            return AvaliacaoDAL.GetById(idAvaliacao);
        }
    }
}
