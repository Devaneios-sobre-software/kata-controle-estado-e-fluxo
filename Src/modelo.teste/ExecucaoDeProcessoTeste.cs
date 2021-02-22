using System;
using Xunit;
using modelo.Processos.MotorDeCarro;
using modelo.Processos.Mapeamento;
using modelo.Processos.Common;

namespace modelo.teste
{
    public class ExecucaoDeProcessoTeste
    {
        [Fact]
        public void DeveExecutarProcessoDeMontagemDeMotorDeCarroComSucesso()
        {
            var processoMontado = new ProcessoBuilder()
                .AdicionarMapeamento(new ProcessoMapeamento())
                .AdicionarValidacao(new ProcessoValidacao())
                .Adicionar(new CabecoteProcesso())
                .Adicionar(new ComandoDeValvulaProcesso())
                .Adicionar(new CilindroProcesso())
                .Adicionar(new VirabrequinProcesso())
                .Adicionar(new PistaoProcesso())
                .Adicionar(new BielaProcesso())
                .Adicionar(new CarterDeOleoMotorProcesso())
                .Adicionar(new CamaraDeCombustaoProcesso());

            var pilha = new ProcessoExecucaoPilhaService(new DadoBoxDto(new DadoImutavelDto("aluminio")));
            var resultado = pilha.RodarPilha(processoMontado).ObterResultadoDeExecucao();

            Assert.True(resultado.DadoDto?.ToString() == "aluminio");
        }

        [Fact]
        public void DeveExecutarProcessoDeValidacaoComSucesso()
        {
            Func<string, bool> specValidacao = (p) => p != null;

            var processoMontado = new ProcessoBuilder()
                .AdicionarValidacao(new CabecoteValidacaoProcesso());

            var resultado = new ProcessoExecucaoPilhaService(new DadoBoxDto(new DadoImutavelDto("aluminio")))
                            .RodarPilha(processoMontado)
                            .ObterResultadoDeExecucao();

            Assert.True(resultado.DadoDto?.ToString() == "aluminio");

        }
    }
}
