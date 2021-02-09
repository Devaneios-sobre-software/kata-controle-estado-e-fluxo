using System;
using Xunit;

namespace modelo.teste
{
    public class ExecucaoDeProcesso
    {
        [Fact]
        public void DeveExecutarProcessoComSucesso()
        {
            var processoMontado = new ProcessoBuilder()
                .Adicionar("Processo1")
                .Adicionar("Processo2")
                .Adicionar("Processo3");

            var resultado = new ProcessoExecucaoPilhaService()
                .Executar(processoMontado);

            Assert.True(resultado == "Processo3");
        }
    }
}
