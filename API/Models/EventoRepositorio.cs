using Library.Business;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class EventoRepositorio : IRepositorio<Evento>
    {
        public int Delete(int id)
        {
            return EventoBLL.Delete(id);
        }

        public IEnumerable<Evento> GetAll()
        {
            return EventoBLL.GetAll();
        }

        public Evento GetById(int? id)
        {
            return EventoBLL.GetById(id.Value);
        }

        public int Insert(Evento item)
        {
            return EventoBLL.Insert(item);
        }

        public int Update(Evento item)
        {
            return EventoBLL.Update(item);
        }
    }
}