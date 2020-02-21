using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Projeto
    {
        private int      idProjeto;
        private int      idTurma;
        private string   nomeProjeto;
        private string   localProjeto;
        private DateTime dtProjeto;
        private string   descProjeto;

        public int IdProjeto { get => idProjeto; set => idProjeto = value; }
        public int IdTurma { get => idTurma; set => idTurma = value; }
        public string NomeProjeto { get => nomeProjeto; set => nomeProjeto = value; }
        public string LocalProjeto { get => localProjeto; set => localProjeto = value; }
        public DateTime DtProjeto { get => dtProjeto; set => dtProjeto = value; }
        public string DescProjeto { get => descProjeto; set => descProjeto = value; }
    }
}
