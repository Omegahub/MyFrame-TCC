using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public interface IRepositorio<T>
    {
        int Insert(T item);

        int Update(T item);

        int Delete(int id);

        IEnumerable<T> GetAll();

        T GetById(int? id);
    }
}
