using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class ProjetoBLL
    {
        public static int Insert(Projeto p)
        {
            return ProjetoDAL.Insert(p);
        }

        public static int Update(Projeto p)
        {
            return ProjetoDAL.Update(p);
        }

        public static int Delete(int idProjeto)
        {
            return ProjetoDAL.Delete(idProjeto);
        }

        public static List<Projeto> GetAll()
        {
            return ProjetoDAL.GetAll();
        }

        public static Projeto GetById(int idProjeto)
        {
            return ProjetoDAL.GetById(idProjeto);
        }
    }
}
