using modelo.Processos.Common;

namespace modelo.Processos.RodaDeCarro.CaixaMarcha
{
    public class LubrificarProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}