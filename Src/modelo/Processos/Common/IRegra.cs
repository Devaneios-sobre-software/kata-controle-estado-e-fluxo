using System;
using System.Linq.Expressions;

namespace modelo.Processos.Common
{
    public interface IRegra
    {
        IDadoDto ObjetoTestado { get; }
        string Mensagem { get; }
        Expression<Func<IDadoDto, bool>> Expressao { get; }
        ResultadoRegra Resultado { get; }

        IRegra Executar();

    }
}