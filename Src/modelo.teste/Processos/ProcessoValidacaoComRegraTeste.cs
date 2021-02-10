using System;
using modelo.Processos;
using modelo.Processos.MotorDeCarro;
using modelo.Processos.MotorDeCarro.Dtos;
using modelo.Processos.Validacao;
using Xunit;

namespace modelo.teste.Processos
{
    public class ProcessoValidacaoComRegraTeste
    {
        [Fact]
        public void DeveGerarNotificacaoDeInexistenciaDeMotor()
        {

            (string msg, Func<IPossuiMotor, bool> regra) regra = (msg: "Entrada nao possui motor", regra: (p) => p.Motor == null);

            var processoMontado = new ProcessoBuilder()
                .AdicionarValidacao(new ProcessoValidacao(regra))
                .Adicionar(new CabecoteProcesso());

            var resultado = new ProcessoExecucaoPilhaService(new DadoBoxDto(new CarroUno1_0 { Nome = "Uno", AnoFabricacao = 2020 }))
                .RodarPilha(processoMontado);

            var not = resultado.Notificador.Obter().GetEnumerator();

            not.MoveNext();


            Assert.True(not.Current?.ToString() == "Entrada nao possui motor");
        }
    }
}