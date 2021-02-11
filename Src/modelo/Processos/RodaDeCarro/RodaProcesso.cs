using modelo.Processos.Common;

namespace modelo.Processos.RodaDeCarro
{
    public class RodaProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}