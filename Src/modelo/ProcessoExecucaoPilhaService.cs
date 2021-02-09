using System.Collections.Generic;
using modelo.Processos;

namespace modelo
{
    public sealed class ProcessoExecucaoPilhaService
    {
        ProcessoBuilder processoMontado;
        IDadoBoxDto dadoInicial;
        IList<IDadoBoxDto> lista;

        public ProcessoExecucaoPilhaService(IDadoBoxDto dadoInicial)
        {
            this.dadoInicial = dadoInicial;
            lista = new List<IDadoBoxDto>
            {
                dadoInicial
            };
        }

        public IDadoBoxDto RodarPilha(ProcessoBuilder processoMontado)
        {
            var processos = processoMontado.Build();

            for (sbyte indice = 0; indice < processos.Count; indice++)
            {
                lista.Add(processos[indice].Executar(lista[indice]));
            }

            return lista[lista.Count - 1];
        }
    }
}