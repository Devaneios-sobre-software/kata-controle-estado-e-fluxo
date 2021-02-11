using modelo.Processos.Common;

namespace modelo.Processos.MotorDeCarro
{
    public sealed class CabecoteProcesso : IProcesso
    {
        public CabecoteProcesso()
        {
        }
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}