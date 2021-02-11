using modelo.Factory;
using modelo.Processos;
using modelo.Processos.Mapeamento;
using modelo.Processos.MotorDeCarro;
using modelo.Processos.MotorDeCarro.Dtos;
using modelo.Processos.Validacao;
using Xunit;

namespace modelo.teste.Processos
{
    public class CabecoteProcessoTeste
    {
        [Fact]
        public void DeveAdicionarMotorAoCarro()
        {
            var processoMontado = new ProcessoBuilder()
                .AdicionarMapeamento(new ProcessoMapeamento())
                .AdicionarValidacao(new ProcessoValidacao())
                .Adicionar(new CabecoteProcesso());

            var resultado = new ProcessoExecucaoPilhaService(new DadoBoxDto(new CarroUno1_0 { Nome = "Uno", AnoFabricacao = 2020 }))
                .RodarPilha(processoMontado)
                .ObterResultadoDeExecucao();

            Assert.True(((Motor)((IPossuiMotor)resultado?.DadoDto)?.Motor)?.Marca == "Bosh" && ((CarroUno1_0)resultado.DadoDto).Nome == "Uno");
        }

        [Fact]
        public void DeveGerarNotificacaoDeInexistenciaDeMotor()
        {
            var processoMontado = new ProcessoBuilder()
                .AdicionarValidacao(new ProcessoValidacao())
                .Adicionar(new CabecoteProcesso());

            var resultado = new ProcessoExecucaoPilhaService(new DadoBoxDto(new CarroUno1_0 { Nome = "Uno", AnoFabricacao = 2020 }))
                .RodarPilha(processoMontado)
                .ObterResultadoDeExecucao();

            var not = resultado.Notificador.Obter().GetEnumerator();

            not.MoveNext();


            Assert.True(not.Current?.ToString() == "Entrada nao possui motor");
        }

    }
}