using ApiCopaFilmes.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiCopaFilmes.Services
{
    public class CampeonatoService
    {
        public Vencedores GerarVencedores(IEnumerable<Filme> filmes)
        {
            var vencedores = new Vencedores();

            var listaOrdenadaPorNota = filmes.OrderByDescending(x => x.Nota);

            if (listaOrdenadaPorNota.ElementAt(0).Nota != listaOrdenadaPorNota.ElementAt(1).Nota)
            {
                vencedores.PrimeiroLugar = listaOrdenadaPorNota.ElementAt(0);
                vencedores.SegundoLugar = listaOrdenadaPorNota.ElementAt(1);

                return vencedores;
            }

            var novaLista = new List<Filme>() { listaOrdenadaPorNota.ElementAt(0), listaOrdenadaPorNota.ElementAt(1) };
            var ordenadosPorTitulo = novaLista.OrderBy(x => x.Titulo);

            return new Vencedores
            {
                PrimeiroLugar = ordenadosPorTitulo.ElementAt(0),
                SegundoLugar = ordenadosPorTitulo.ElementAt(1)
            };
        }

    }
}
