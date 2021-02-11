using modelo.Processos.Common;

namespace modelo.Processos.RodaDeCarro.Eixo
{
    public class ColocarRodaNoEixoProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}