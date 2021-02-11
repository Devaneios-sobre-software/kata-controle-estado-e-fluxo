using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace modelo.Processos.Common
{
    public class PoliticaRegraBuilder : IPoliticaRegraBuilder
    {
        private IList<IRegra> regras;

        public ResultadoPolitica Resultado { get; private set; }

        public PoliticaRegraBuilder()
        {
            this.regras = new List<IRegra>();
        }

        public IPoliticaRegraBuilder AdicionarRegra(IRegra regra)
        {
            this.regras.Add(regra);
            return this;
        }

        public IPoliticaRegraBuilder Executar()
        {
            Resultado = regras.All(a => a.Executar().Resultado == ResultadoRegra.REPROVADA) ? ResultadoPolitica.REPROVADA : ResultadoPolitica.APROVADA;
            return this;
        }
    }
}