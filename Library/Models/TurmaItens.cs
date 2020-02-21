using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class TurmaItens
    {
        private int    idTurma;
        private int    idTurmaItem;
        private string itensNecessarios;

        public int IdTurma { get => idTurma; set => idTurma = value; }
        public int IdTurmaItem { get => idTurmaItem; set => idTurmaItem = value; }
        public string ItensNecessarios { get => itensNecessarios; set => itensNecessarios = value; }
    }
}
