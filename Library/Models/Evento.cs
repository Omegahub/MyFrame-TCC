using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Evento
    {
        private int      idEvento;
        private int      idGestor;
        private string   nomeEvento;
        private string   enderecoEvento;
        private DateTime dtEvento;
        private string   descEvento;
        private int      capaciMaxEvento;

        public int IdEvento { get => idEvento; set => idEvento = value; }
        public int IdGestor { get => idGestor; set => idGestor = value; }
        public string NomeEvento { get => nomeEvento; set => nomeEvento = value; }
        public string EnderecoEvento { get => enderecoEvento; set => enderecoEvento = value; }
        public DateTime DtEvento { get => dtEvento; set => dtEvento = value; }
        public string DescEvento { get => descEvento; set => descEvento = value; }
        public int CapaciMaxEvento { get => capaciMaxEvento; set => capaciMaxEvento = value; }
    }
}
