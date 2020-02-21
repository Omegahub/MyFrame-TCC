using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class TurmaBLL
    {
        public static int Insert(Turma t)
        {
            return TurmaDAL.Insert(t);
        }

        public static int Update(Turma t)
        {
            return TurmaDAL.Update(t);
        }

        public static int Delete(int idTurma)
        {
            return TurmaDAL.Delete(idTurma);
        }

        public static List<Turma> GetAll()
        {
            return TurmaDAL.GetAll();
        }

        public static Turma GetById(int idTurma)
        {
            return TurmaDAL.GetById(idTurma);
        }
    }
}
