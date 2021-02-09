using System;
using System.Collections.Generic;
using modelo.Processos;

namespace modelo
{
    public sealed class ProcessoBuilder
    {
        readonly IList<IProcesso> processos = new List<IProcesso>();

        public ProcessoBuilder()
        {

        }

        public ProcessoBuilder Adicionar(IProcesso processo)
        {
            this.processos.Add(processo);
            return this;
        }

        public IList<IProcesso> Build()
        {
            return this.processos;
        }
    }
}
