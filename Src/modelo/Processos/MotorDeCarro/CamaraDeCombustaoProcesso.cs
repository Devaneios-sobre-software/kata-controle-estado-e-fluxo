using modelo.Processos.Common;

namespace modelo.Processos.MotorDeCarro
{
    public class CamaraDeCombustaoProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}