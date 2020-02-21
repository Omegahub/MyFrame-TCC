using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    public class ConsumidorBLL
    {
        public static int Insert(Consumidor c)
        {
            return ConsumidorDAL.Insert(c);
        }

        public static int Update(Consumidor c)
        {
            return ConsumidorDAL.Update(c);
        }

        public static int Delete(int id)
        {
            return ConsumidorDAL.Delete(id);
        }

        public static List<Consumidor> GetAll()
        {
            return ConsumidorDAL.GetAll();
        }

        public static Consumidor GetById(int idConsumidor)
        {
            return ConsumidorDAL.GetById(idConsumidor);
        }
    }
}
