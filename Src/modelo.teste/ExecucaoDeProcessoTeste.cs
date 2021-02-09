using System;
using Xunit;
using modelo.Processos.MotorDeCarro;
using modelo.Processos;

namespace modelo.teste
{
    public class ExecucaoDeProcessoTeste
    {
        [Fact]
        public void DeveExecutarProcessoDeMontagemDeMotorDeCarroComSucesso()
        {
            var processoMontado = new ProcessoBuilder()
                .Adicionar(new CabecoteProcesso())
                .Adicionar(new ComandoDeValvulaProcesso())
                .Adicionar(new CilindroProcesso())
                .Adicionar(new VirabrequinProcesso())
                .Adicionar(new PistaoProcesso())
                .Adicionar(new BielaProcesso())
                .Adicionar(new CarterDeOleoMotorProcesso())
                .Adicionar(new CamaraDeCombustaoProcesso());

            var resultado = new ProcessoExecucaoPilhaService(new DadoBoxDto(new DadoDto("aluminio")))
                .RodarPilha(processoMontado);

            Assert.True(resultado.DadoDto?.ToString() == "aluminio");
        }

        [Fact]
        public void DeveExecutarProcessoDeValidacaoComSucesso()
        {
            Func<string, bool> specValidacao = (p) => p != null;

            var processoMontado = new ProcessoBuilder()
                .Adicionar(new CabecoteValidacaoProcesso());

            var resultado = new ProcessoExecucaoPilhaService(new DadoBoxDto(new DadoDto("aluminio")))
                            .RodarPilha(processoMontado);

            Assert.True(resultado.DadoDto?.ToString() == "aluminio");

        }
    }
}
