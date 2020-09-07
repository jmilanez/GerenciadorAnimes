using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAnimes.Model
{
    public class Animes
    {
        public string ID { get; set; }

        public string Nome { get; set; }

        public string Genero { get; set; }

        public bool Visualizado { get; set; }

        public bool Recomendavel { get; set; }

        public int Nota { get; set; }
    }
}
