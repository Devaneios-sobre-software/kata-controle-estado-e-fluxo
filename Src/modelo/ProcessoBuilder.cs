using System;
using System.Collections.Generic;
using modelo.Processos;
using modelo.Processos.Common;

namespace modelo
{
    public sealed class ProcessoBuilder
    {
        readonly Guid ProcessoId;
        readonly IList<IProcesso> processos;

        public ProcessoBuilder()
        {
            this.processos = new List<IProcesso>();
            this.ProcessoId = Guid.NewGuid();
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
