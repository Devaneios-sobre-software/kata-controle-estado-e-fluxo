using System.Collections.Generic;
using modelo.Processos;

namespace modelo
{
    public sealed class ProcessoExecucaoPilhaService
    {

        IList<IDadoBoxDto> retornosProcessosExecutados;

        public ProcessoExecucaoPilhaService(IDadoBoxDto dadoInicial)
        {
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
                return null;
            }
            else
            {
                return retornosProcessosExecutados[retornosProcessosExecutados.Count - 1];
            }
        }
    }
}