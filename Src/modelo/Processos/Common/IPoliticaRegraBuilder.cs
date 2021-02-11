using System;
using System.Linq.Expressions;

namespace modelo.Processos.Common
{
    public interface IPoliticaRegraBuilder
    {
        ResultadoPolitica Resultado { get; }

        IPoliticaRegraBuilder AdicionarRegra(IRegra regra);
        IPoliticaRegraBuilder Executar();
    }
}