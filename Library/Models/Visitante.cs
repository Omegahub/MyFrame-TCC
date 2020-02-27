using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Visitante
    {
        private int      idVisitante;
        private string   nomeVisitante;
        private string   cpfVisitante;
        private string   endVisitante;
        private string   telVisitante;
        private string   emailVisitante;
        private DateTime dtNascVisitante;

        public int IdVisitante { get => idVisitante; set => idVisitante = value; }
        public string NomeVisitante { get => nomeVisitante; set => nomeVisitante = value; }
        public string CpfVisitante { get => cpfVisitante; set => cpfVisitante = value; }
        public string EndVisitante { get => endVisitante; set => endVisitante = value; }
        public string TelVisitante { get => telVisitante; set => telVisitante = value; }
        public string EmailVisitante { get => emailVisitante; set => emailVisitante = value; }
        public DateTime DtNascVisitante { get => dtNascVisitante; set => dtNascVisitante = value; }
    }
}
