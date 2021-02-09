namespace modelo.Processos.RodaDeCarro
{
    public class PneuProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}