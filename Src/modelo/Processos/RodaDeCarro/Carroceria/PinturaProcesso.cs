using modelo.Processos.Common;

namespace modelo.Processos.RodaDeCarro.Carroceria
{
    public class PinturaProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}