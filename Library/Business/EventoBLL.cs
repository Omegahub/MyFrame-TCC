using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class EventoBLL
    {
        public static int Insert(Evento e)
        {
            return EventoDAL.Insert(e);
        }

        public static int Update(Evento e)
        {
            return EventoDAL.Update(e);
        }

        public static int Delete(int idEvento)
        {
            return EventoDAL.Delete(idEvento);
        }

        public static List<Evento> GetAll()
        {
            return EventoDAL.GetAll();
        }

        public static Evento GetById(int idEvento)
        {
            return EventoDAL.GetById(idEvento);
        }
    }
}
