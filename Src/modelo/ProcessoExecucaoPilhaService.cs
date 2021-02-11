using System.Collections.Generic;
using modelo.Processos;

namespace modelo
{
    public sealed class ProcessoExecucaoPilhaService
    {
        IDadoBoxDto dadoInicial;
        IList<IDadoBoxDto> retornosProcessosExecutados;

        public ProcessoExecucaoPilhaService(IDadoBoxDto dadoInicial)
        {
            this.dadoInicial = dadoInicial;
            retornosProcessosExecutados = new List<IDadoBoxDto>
            {
                dadoInicial
            };
        }

        public ProcessoExecucaoPilhaService RodarPilha(ProcessoBuilder processoMontado)
        {
            var processosMontados = processoMontado.Build();

            for (sbyte indice = 0; indice < processosMontados.Count; indice++)
            {
                retornosProcessosExecutados.Add(processosMontados[indice].Executar(retornosProcessosExecutados[indice]));
            }

            return this;
        }

        public IEnumerable<IDadoBoxDto> ObterHistoricoExecucao()
        {
            return this.retornosProcessosExecutados;
        }

        public IDadoBoxDto ObterResultadoDeExecucao()
        {
            var quantidade = retornosProcessosExecutados.Count;
            if (quantidade == 0)
            {
                return this.dadoInicial;
            }
            else
            {
                return retornosProcessosExecutados[retornosProcessosExecutados.Count - 1];
            }
        }
    }
}