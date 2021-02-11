using modelo.Processos.Common;

namespace modelo.Processos.MotorDeCarro
{
    public class CabecoteValidacaoProcesso : IProcessoValidacao
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}