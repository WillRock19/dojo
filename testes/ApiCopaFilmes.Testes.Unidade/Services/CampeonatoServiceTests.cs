using ApiCopaFilmes.Models;
using ApiCopaFilmes.Services;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Services
{
    public class CampeonatoServiceTests
    {
        private CampeonatoService _campeonatoService;
        private Filme notaAltaA, notaAltaB, notaBaixa;

        [SetUp]
        public void Setup()
        {
            _campeonatoService = new CampeonatoService();
            notaAltaA = new Filme
            {
                Ano = 2014,
                Id = 1,
                Nota = 9,
                Titulo = "Alana"
            };
            notaAltaB = new Filme
            {
                Ano = 2014,
                Id = 1,
                Nota = 9,
                Titulo = "Bruno"
            };
            notaBaixa = new Filme
            {
                Ano = 2009,
                Id = 2,
                Nota = 1,
                Titulo = "Teles"
            };
        }

        [Test(Description = "")]
        public void GerarVencedoresDeveRetornarCampeaoEViceCasoOPrimeiroSejaMaiorQueOSegundo()
        {
            var filmes = new[] { notaBaixa, notaAltaA };
            var vencedores = _campeonatoService.GerarVencedores(filmes);

            vencedores.PrimeiroLugar.Should().Be(notaAltaA);
            vencedores.SegundoLugar.Should().Be(notaBaixa);
        }

        [Test]
        public void GerarVencedoresDeveRetornarCampeaoEViceCasoOSegundoSejaMaiorQueOPrimeiro()
        {
            var filmes = new[] { notaAltaA, notaBaixa };

            var vencedores = _campeonatoService.GerarVencedores(filmes);

            vencedores.PrimeiroLugar.Should().Be(notaAltaA);
            vencedores.SegundoLugar.Should().Be(notaBaixa);
        }

        [Test]
        public void GerarVencedoresDeveRetornarCampeaoEViceCasoRecebaListaComMultiplosItems()
        {
            var filmeMedio1 = new Filme
            {
                Ano = 2014,
                Id = 1,
                Nota = 4,
                Titulo = "Willaim"
            };
            var filmeMedio2 = new Filme
            {
                Ano = 2014,
                Id = 1,
                Nota = 5,
                Titulo = "Willaim"
            };

            var filmes = new[] { notaBaixa, filmeMedio1, filmeMedio2, notaAltaA };
            var vencedores = _campeonatoService.GerarVencedores(filmes);

            vencedores.PrimeiroLugar.Should().Be(notaAltaA);
            vencedores.SegundoLugar.Should().Be(filmeMedio2);
        }

        [Test]
        public void GerarVencedoresDeveRetornarCampeaoEViceEscolhidosPorOrdemAlfabeticaCasoAsNotasSejamIguais()
        {
            var filmeMedio1 = new Filme
            {
                Ano = 2014,
                Id = 1,
                Nota = 4,
                Titulo = "Willaim"
            };
            var filmeMedio2 = new Filme
            {
                Ano = 2014,
                Id = 1,
                Nota = 5,
                Titulo = "Willaim"
            };

            var filmes = new[] { notaBaixa, filmeMedio1, notaAltaB, notaAltaA };
            var vencedores = _campeonatoService.GerarVencedores(filmes);

            vencedores.PrimeiroLugar.Should().Be(notaAltaA);
            vencedores.SegundoLugar.Should().Be(notaAltaB);
        }

        [Test]
        public void GerarVencedoresNaoDeveFazerNadaCasoListaTenhaMenosDeOitoFilmes()
        {
            false.Should().BeTrue();
        }

        [Test]
        public void GerarVencedoresDeveRetornarCampeaoEViceEscolhidosPorOrdemAlfabeticaCasoAsNotasSejam()
        {
            var filmes = GerarListaDeFilmes();
            var vencedorEsperado = filmes.Select(x => x.Titulo = "H8");
            var viceEsperado = filmes.Select(x => x.Titulo = "G7");
            var vencedores = _campeonatoService.GerarVencedores(filmes);

            vencedores.PrimeiroLugar.Should().Be(vencedorEsperado);
            vencedores.SegundoLugar.Should().Be(viceEsperado);
        }

        private List<Filme> GerarListaDeFilmes()
        {
            var filmeMedioA1 = new Filme { Ano = 2014, Id = 1, Nota = 9, Titulo = "A1" };
            var filmeMedioB9 = new Filme { Ano = 2014, Id = 2, Nota = 2, Titulo = "B9" };
            var filmeMedioC3 = new Filme { Ano = 2014, Id = 3, Nota = 1, Titulo = "C3" };
            var filmeMedioD4 = new Filme { Ano = 2014, Id = 4, Nota = 1, Titulo = "D4" };
            var filmeMedioE5 = new Filme { Ano = 2014, Id = 5, Nota = 1, Titulo = "E5" };
            var filmeMedioF6 = new Filme { Ano = 2014, Id = 6, Nota = 1, Titulo = "F6" };
            var filmeMedioG7 = new Filme { Ano = 2014, Id = 7, Nota = 8, Titulo = "G7" };
            var filmeMedioH8 = new Filme { Ano = 2014, Id = 8, Nota = 10, Titulo = "H8" };

            return new List<Filme>()
            {
                filmeMedioA1, filmeMedioB9, filmeMedioC3, filmeMedioD4, filmeMedioE5, filmeMedioF6, filmeMedioG7, filmeMedioH8
            };
        }
    }
}