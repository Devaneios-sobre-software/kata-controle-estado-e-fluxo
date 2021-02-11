using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using modelo.Processos;
using modelo.Processos.Validacao;
using Xunit;

namespace modelo.teste.Processos
{
    public class ExecucaoDeProcessosDiferentesNumaMesmaPilhaTeste
    {
        [Fact]
        public void DeveExecutarDoisProcessosDiferentesComProblemaDeValidacao()
        {
            IList<(string msg, Expression<Func<IDadoDto, bool>> regra)> regrasProcessoMontado1 = new List<(string msg, Expression<Func<IDadoDto, bool>> regra)>
            {
                (msg: "Regra processo montado 1", regra: (p) => true)
            };

            IList<(string msg, Expression<Func<IDadoDto, bool>> regra)> regrasProcessoMontado2 = new List<(string msg, Expression<Func<IDadoDto, bool>> regra)>
            {
                (msg: "Regra processo montado 2", regra: (p) => true)
            };


            var processoMontado1 = new ProcessoBuilder()
                .AdicionarValidacao(new ProcessoValidacao(regrasProcessoMontado1));

            var processoMontado2 = new ProcessoBuilder()
                .AdicionarValidacao(new ProcessoValidacao(regrasProcessoMontado2));

            var execucaoProcessos = new ProcessoExecucaoPilhaService(new DadoBoxDto())
                .RodarPilha(processoMontado1)
                .RodarPilha(processoMontado2)
                .ObterResultadoDeExecucao();

            var not = execucaoProcessos.Notificador.Obter().GetEnumerator();

            IList<string> nots = new List<string>();

            while (not?.MoveNext() ?? false)
            {
                nots.Add(not.Current as string);
            }

            Assert.True(
                nots.Any(a => a == "Regra processo montado 1") &&
                nots.Any(a => a == "Regra processo montado 2")
            );
        }

        [Fact]
        public void DeveExecutarDoisProcessosDiferentesSemValidacao()
        {
            var processoMontado1 = new ProcessoBuilder()
                .AdicionarValidacao(new ProcessoValidacao());

            var processoMontado2 = new ProcessoBuilder()
                .AdicionarValidacao(new ProcessoValidacao());

            var execucaoProcessos = new ProcessoExecucaoPilhaService(new DadoBoxDto())
                .RodarPilha(processoMontado1)
                .RodarPilha(processoMontado2);

            var processosExecutados = execucaoProcessos.ObterResultadoDeExecucao();

            var not = processosExecutados.Notificador.Obter().GetEnumerator();

            IList<string> nots = new List<string>();

            while (not?.MoveNext() ?? false)
            {
                nots.Add(not.Current as string);
            }

            Assert.True(
                execucaoProcessos.ObterHistoricoExecucao().Count() == 3 &&
                nots.Count() == 0
            );
        }
    }
}