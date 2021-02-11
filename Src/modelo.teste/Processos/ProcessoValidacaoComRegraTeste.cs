using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            IList<(string msg, Expression<Func<IDadoDto, bool>> regra)> regras = new List<(string msg, Expression<Func<IDadoDto, bool>> regra)>
            {
                (msg: "Entrada nao é motor", regra: (p) => p is IPossuiMotor),
                (msg: "Entrada nao possui motor", regra: (p) => (p as IPossuiMotor) == null),
                (msg: "Entrada nao possui motor Bosh", regra: (p) => ((p as IPossuiMotor) as Motor) is Motor &&  ((p as IPossuiMotor) as Motor).Marca == "Bosh")
            };

            var processoMontado = new ProcessoBuilder()
                .AdicionarValidacao(new ProcessoValidacao(regras))
                .Adicionar(new CabecoteProcesso());

            var exec = new ProcessoExecucaoPilhaService(new DadoBoxDto(new CarroUno1_0 { Nome = "Uno", AnoFabricacao = 2020 }))
                .RodarPilha(processoMontado);

            var resultado = exec
            .ObterResultadoDeExecucao();

            var not = resultado.Notificador.Obter().GetEnumerator();

            not.MoveNext();

            Assert.True(not.Current?.ToString() == "Entrada nao é motor");
        }
    }
}