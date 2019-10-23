using ApiCopaFilmes.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiCopaFilmes.Services
{
    public class CampeonatoService
    {
        public Vencedores GerarVencedores(IEnumerable<Filme> filmes)
        {
            var listaOrdenadaPorNota = filmes.OrderByDescending(x => x.Nota);
            
            //if(listaOrdenadaPorNota.ElementAt(0).Nota == listaOrdenadaPorNota.ElementAt(1).Nota)
            //    listaOrdenadaPorNota = filmes.OrderByDescending(x => x.Titulo);

            return new Vencedores
            {
                PrimeiroLugar = listaOrdenadaPorNota.ElementAt(0),
                SegundoLugar = listaOrdenadaPorNota.ElementAt(1)
            };
        }
    }
}
