using System;
using System.Linq.Expressions;
using modelo.Processos.Common;
using Xunit;

namespace modelo.teste.Processos.Regras
{
    public class EstruturaDePoliticaDeRegraTeste
    {
        [Fact]
        public void DeveExecutarRegraSimplesEReprovala()
        {
            IRegra regra = new Regra { Mensagem = "mensagem", Expressao = a => a == null };

            var resultado = regra.Executar().Resultado;

            Assert.True(resultado == ResultadoRegra.REPROVADA);
        }

        [Fact]
        public void DeveExecutarRegraSimplesEAprovala()
        {
            IRegra regra = new Regra { ObjetoTestado = new DadoDto(null), Mensagem = "mensagem", Expressao = a => a == null };

            var resultado = regra.Executar().Resultado;

            Assert.True(resultado == ResultadoRegra.APROVADA);
        }

        [Fact]
        public void DeveExecutarPoliticaEReprovala()
        {
            IRegra regra1 = new Regra { ObjetoTestado = new DadoDto(null), Mensagem = "mensagem", Expressao = a => a.ToString() == null };
            IRegra regra2 = new Regra { Mensagem = "mensagem", Expressao = a => a == null };
            IRegra regra3 = new Regra { Mensagem = "mensagem", Expressao = a => a == null };

            IPoliticaRegraBuilder politica = new PoliticaRegraBuilder()
                .AdicionarRegra(regra1)
                .AdicionarRegra(regra2)
                .AdicionarRegra(regra3);

            var res = politica.Executar().Resultado;

            Assert.True(res == ResultadoPolitica.REPROVADA);
        }

        [Fact]
        public void DeveExecutarPoliticaEAprovada()
        {
            IRegra regra1 = new Regra { ObjetoTestado = new DadoDto("dado1"), Mensagem = "mensagem", Expressao = a => a.ToString() == null };
            IRegra regra2 = new Regra { ObjetoTestado = new DadoDto(null), Mensagem = "mensagem", Expressao = a => a == null };
            IRegra regra3 = new Regra { Mensagem = "mensagem", Expressao = a => a != null };

            IPoliticaRegraBuilder politica = new PoliticaRegraBuilder()
                .AdicionarRegra(regra1)
                .AdicionarRegra(regra2)
                .AdicionarRegra(regra3);

            var res = politica.Executar().Resultado;

            Assert.True(res == ResultadoPolitica.APROVADA);
        }
    }
}