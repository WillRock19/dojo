using System.Collections.Generic;
using System.Linq;

namespace ApiCopaFilmes.Models
{
    public class Vencedores
    {
        public Filme PrimeiroLugar { get; set; }
        public Filme SegundoLugar { get; set; }

        public Vencedores()
        {

        }

        public Vencedores(Filme primeiroFilme, Filme segundoFilme) =>
            DefinirPrimeiroESegundoLugar(primeiroFilme, segundoFilme);

        public void DefinirPrimeiroESegundoLugar(Filme primeiroFilme, Filme segundoFilme)
        {
            if (primeiroFilme.Nota == segundoFilme.Nota)
                OrdenarPorTitulo(primeiroFilme, segundoFilme);
            else
                OrdenarPorNota(primeiroFilme, segundoFilme);
        }

        private void OrdenarPorNota(Filme primeiroFilme, Filme segundoFilme)
        {
            var listaFilmes = new List<Filme>()
            {
                primeiroFilme,
                segundoFilme
            };

            var listaOrdenada = listaFilmes.OrderByDescending(x => x.Nota);

            PrimeiroLugar = listaOrdenada.ElementAt(0);
            SegundoLugar = listaOrdenada.ElementAt(1);
        }

        private void OrdenarPorTitulo(Filme primeiroFilme, Filme segundoFilme)
        {
            var listaFilmes = new List<Filme>()
            {
                primeiroFilme,
                segundoFilme
            };

            var listaOrdenada = listaFilmes.OrderBy(x => x.Titulo);

            PrimeiroLugar = listaOrdenada.ElementAt(0);
            SegundoLugar = listaOrdenada.ElementAt(1);
        }
    }

}
