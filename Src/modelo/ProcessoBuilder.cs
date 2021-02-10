using System;
using System.Collections.Generic;
using modelo.Processos;
using modelo.Processos.Common;

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

        public ProcessoBuilder AdicionarValidacao(IProcessoValidacao processo)
        {
            this.processos.Add(processo);
            return this;
        }

        public ProcessoBuilder AdicionarMapeamento(IProcessoMapeamentoDto processo)
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
