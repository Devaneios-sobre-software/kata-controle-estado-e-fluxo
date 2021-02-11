using modelo.Processos.Common;

namespace modelo.Processos.MotorDeCarro
{
    public class CilindroProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}