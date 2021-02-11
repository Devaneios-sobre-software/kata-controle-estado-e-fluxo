using System;

namespace modelo.Processos.Common
{
    public class DadoBoxIdGlobalExecucao : IDadoBoxIdGlobalExecucao
    {
        Guid id;

        public DadoBoxIdGlobalExecucao()
        {
            this.id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }
}