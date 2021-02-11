using modelo.Processos.Common;

namespace modelo.Processos.RodaDeCarro.CaixaMarcha
{
    public class EncaixarEngrenagensProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}