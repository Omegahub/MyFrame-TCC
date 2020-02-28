using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class GestorBLL
    {
        public static int Insert(Gestor g)
        {
            return GestorDAL.Insert(g);
        }

        public static int Update(Gestor g)
        {
            return GestorDAL.Update(g);
        }
        public static int Delete(int idGestor)
        {
            return GestorDAL.Delete(idGestor);
        }

        public static List<Gestor> GetAll()
        {
            return GestorDAL.GetAll();
        }

        public static Gestor GetById(int idGestor)
        {
            return GestorDAL.GetById(idGestor);
        }
    }
}
