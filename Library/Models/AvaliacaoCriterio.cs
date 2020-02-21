using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class AvaliacaoCriterio
    {
        private int    idAvaliacao;
        private int    idCriterioAvaliacao;
        private int    idVisitante;
        private string criterioAvaliacao;

        public int IdAvaliacao { get => idAvaliacao; set => idAvaliacao = value; }
        public int IdCriterioAvaliacao { get => idCriterioAvaliacao; set => idCriterioAvaliacao = value; }
        public int IdVisitante { get => idVisitante; set => idVisitante = value; }
        public string CriterioAvaliacao { get => criterioAvaliacao; set => criterioAvaliacao = value; }
    }
}
