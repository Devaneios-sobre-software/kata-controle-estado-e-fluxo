using System.Collections.Generic;
using System.Linq;

namespace modelo.Processos.Common
{
    public struct DadoImutavelDto : IDadoDto
    {
        string _dado;
        public int MyProperty { get; set; }
        public IList<string> Lista { get; set; }

        public DadoImutavelDto(string dado, int casa = 0)
        {
            this._dado = dado;
            this.Lista = new List<string>();
            this.MyProperty = 0;
        }

        public override string ToString()
        {
            return this._dado;
        }

        public DadoImutavelDto Clonar()
        {
            return new DadoImutavelDto
            {
                _dado = this._dado,
                MyProperty = this.MyProperty,
                Lista = Lista.Union(this.Lista).ToList()
            };
        }
    }
}