using modelo.Processos.Common;

namespace modelo.Processos.MotorDeCarro
{
    public class CarterDeOleoMotorProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}