using modelo.Processos.Common;

namespace modelo.Processos.MotorDeCarro
{
    public class VirabrequinProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}