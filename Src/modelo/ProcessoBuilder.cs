using System;
using System.Collections.Generic;

namespace modelo
{
    public sealed class ProcessoBuilder
    {
        readonly IList<string> processos = new List<string>();

        public ProcessoBuilder()
        {

        }

        public ProcessoBuilder Adicionar(string processo)
        {
            this.processos.Add(processo);
            return this;
        }

        public IList<string> Build()
        {
            return this.processos;
        }
    }
}
