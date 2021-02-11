using System;
using System.Linq.Expressions;

namespace modelo.Processos.Common
{
    public sealed class Regra : IRegra
    {
        public string Mensagem { get; init; }
        public Expression<Func<IDadoDto, bool>> Expressao { get; init; }
        public ResultadoRegra Resultado { get; private set; }

        public IDadoDto ObjetoTestado { get; init; }

        public IRegra Executar()
        {
            Resultado = this.Expressao.Compile()(this.ObjetoTestado) ? ResultadoRegra.REPROVADA : ResultadoRegra.APROVADA;
            return this;
        }
    }
}