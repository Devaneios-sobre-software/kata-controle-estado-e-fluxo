namespace modelo.Processos.MotorDeCarro
{
    public class PistaoProcesso : IProcesso
    {
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}