using modelo.Processos.Common;

namespace modelo.Processos.MotorDeCarro
{
    public class BielaProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}