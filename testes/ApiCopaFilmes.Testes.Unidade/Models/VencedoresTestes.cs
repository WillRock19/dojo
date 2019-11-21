using ApiCopaFilmes.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCopaFilmes.Testes.Unidade.Models
{
    public class VencedoresTestes
    {
        private Vencedores _vencedores;

        [Test]
        public void DeveInicializarPrimeiroLugarComOFilmeDeNotaMaiorESegundoComFilmeDeNotaMenor()
        {
            var filmeComNotaMaior = new Filme
            {
                Nota = 10,
                Ano = 2010,
                Titulo = "Teste1"
            };

             var filmeComNotaMenor = new Filme
            {
                Nota = 5,
                Ano = 2010,
                Titulo = "Teste2"
            };

            _vencedores = new Vencedores(filmeComNotaMenor, filmeComNotaMaior);

            _vencedores.PrimeiroLugar.Should().Be(filmeComNotaMaior);
            _vencedores.SegundoLugar.Should().Be(filmeComNotaMenor);
        }

        [Test]
        public void DeveInicializarPrimeiroESegundoLugarPorOrdemAlfabeticaCasoAsNotasSejamIguais()
        {
            var filmeComTituloComecaComA = new Filme
            {
                Nota = 10,
                Ano = 2010,
                Titulo = "Armageddon"
            };

            var filmeComTituloComecaComB = new Filme
            {
                Nota = 5,
                Ano = 2010,
                Titulo = "Brasil em crise"
            };

            _vencedores = new Vencedores(filmeComTituloComecaComB, filmeComTituloComecaComA);

            _vencedores.PrimeiroLugar.Should().Be(filmeComTituloComecaComA);
            _vencedores.SegundoLugar.Should().Be(filmeComTituloComecaComB);
        }
    }
}
