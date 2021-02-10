using modelo.Processos.MotorDeCarro.Dtos;

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