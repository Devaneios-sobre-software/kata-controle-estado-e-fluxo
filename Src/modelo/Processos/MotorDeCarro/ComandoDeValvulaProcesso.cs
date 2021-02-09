namespace modelo.Processos.MotorDeCarro
{
    public sealed class ComandoDeValvulaProcesso : IProcesso
    {
        public ComandoDeValvulaProcesso()
        {
        }
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            return entrada;
        }
    }
}