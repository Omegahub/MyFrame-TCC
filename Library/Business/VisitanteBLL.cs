using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class VisitanteBLL
    {
        public static int Insert(Visitante v)
        {
            return VisitanteDAL.Insert(v);
        }

        public static int Update(Visitante v)
        {
            return VisitanteDAL.Update(v);
        }

        public static int Delete(int idVisitante)
        {
            return VisitanteDAL.Delete(idVisitante);
        }

        public static List<Visitante> GetAll()
        {
            return VisitanteDAL.GetAll();
        }

        public static Visitante GetById(int idVisitante)
        {
            return VisitanteDAL.GetById(idVisitante);
        }
    }
}
