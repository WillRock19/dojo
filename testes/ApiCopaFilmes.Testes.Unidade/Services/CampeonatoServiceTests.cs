using ApiCopaFilmes.Models;
using ApiCopaFilmes.Services;
using FluentAssertions;
using NUnit.Framework;

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
            var filmes = new [] { notaBaixa, notaAltaA };
            var vencedores = _campeonatoService.GerarVencedores(filmes);

            vencedores.PrimeiroLugar.Should().Be(notaAltaA);
            vencedores.SegundoLugar.Should().Be(notaBaixa);
        }

        [Test]
        public void GerarVencedoresDeveRetornarCampeaoEViceCasoOSegundoSejaMaiorQueOPrimeiro()
        {
            var filmes = new[] { notaAltaA, notaBaixa};

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
    }
}