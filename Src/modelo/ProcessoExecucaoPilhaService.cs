using System.Collections.Generic;
using modelo.Processos;
using modelo.Processos.Common;

namespace modelo
{
    public sealed class ProcessoExecucaoPilhaService
    {
        IDadoBoxDto dadoInicial;
        IList<IDadoBoxDto> dadosExecutados;

        public ProcessoExecucaoPilhaService(IDadoBoxDto dadoInicial)
        {
            this.dadoInicial = dadoInicial;
            dadosExecutados = new List<IDadoBoxDto>
            {
                dadoInicial
            };
        }

        public ProcessoExecucaoPilhaService RodarPilha(ProcessoBuilder processoMontado)
        {
            var processosMontados = processoMontado.Build();

            for (sbyte indice = 0; indice < processosMontados.Count; indice++)
            {
                dadosExecutados.Add(processosMontados[indice].Executar(dadosExecutados[indice]));
            }

            return this;
        }

        public IEnumerable<IDadoBoxDto> ObterHistoricoExecucao()
        {
            return this.dadosExecutados;
        }

        public IDadoBoxDto ObterResultadoDeExecucao()
        {
            var quantidade = dadosExecutados.Count;
            if (quantidade == 0)
            {
                return this.dadoInicial;
            }
            else
            {
                return dadosExecutados[dadosExecutados.Count - 1];
            }
        }
    }
}