using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Avaliacao
    {
        private int      idAvaliacao;
        private int      idEvento;
        private int      idProjeto;
        private DateTime dtAvaliacao;
        private string   feedback;
        private int   notaAvaliacao;

        public int IdAvaliacao { get => idAvaliacao; set => idAvaliacao = value; }
        public int IdEvento { get => idEvento; set => idEvento = value; }
        public int IdProjeto { get => idProjeto; set => idProjeto = value; }
        public DateTime DtAvaliacao { get => dtAvaliacao; set => dtAvaliacao = value; }
        public string Feedback { get => feedback; set => feedback = value; }
        public int NotaAvaliacao { get => notaAvaliacao; set => notaAvaliacao = value; }
    }
}
