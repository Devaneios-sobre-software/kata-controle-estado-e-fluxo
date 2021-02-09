using modelo.Processos.RodaDeCarro.Eixo;

namespace modelo.Processos.RodaDeCarro
{
    public class EixoProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            var eixo = new ProcessoBuilder()
                .Adicionar(new PneuProcesso())
                .Adicionar(new RodaProcesso())
                .Adicionar(new ColocarRodaNoEixoProcesso());

            return new ProcessoExecucaoPilhaService(entrada)
                .RodarPilha(eixo);
        }
    }
}