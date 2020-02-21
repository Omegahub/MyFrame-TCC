using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Turma
    {
        private int    idTurma;
        private string nomeCurso;

        public int IdTurma { get => idTurma; set => idTurma = value; }
        public string NomeCurso { get => nomeCurso; set => nomeCurso = value; }
    }
}
