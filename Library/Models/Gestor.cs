using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Gestor
    {
        private int      idGestor;
        private string   nomeGestor;
        private DateTime dtNascGestor;

        public int IdGestor { get => idGestor; set => idGestor = value; }
        public string NomeGestor { get => nomeGestor; set => nomeGestor = value; }
        public DateTime DtNascGestor { get => dtNascGestor; set => dtNascGestor = value; }
    }
}
