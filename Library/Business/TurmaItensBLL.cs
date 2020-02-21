using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class TurmaItensBLL
    {
        public static int Insert(TurmaItens ti)
        {
            return TurmaItensDAL.Insert(ti);
        }

        public static int Update(TurmaItens ti)
        {
            return TurmaItensDAL.Update(ti);
        }

        public static int Delete(int idTurmaItens)
        {
            return TurmaItensDAL.Delete(idTurmaItens);
        }

        public static List<TurmaItens> GetAll()
        {
            return TurmaItensDAL.GetAll();
        }

        public static TurmaItens GetById(int idTurmaItens)
        {
            return TurmaItensDAL.GetById(idTurmaItens);
        }
    }
}
