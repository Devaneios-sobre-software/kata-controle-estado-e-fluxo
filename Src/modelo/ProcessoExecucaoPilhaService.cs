namespace modelo
{
    public sealed class ProcessoExecucaoPilhaService
    {
        ProcessoBuilder processoMontado;

        public string Executar(ProcessoBuilder processoMontado)
        {
            string ultimoProcessado = string.Empty;

            var processos = processoMontado.Build();

            foreach (var item in processos)
            {
                ultimoProcessado = item;
            }

            return ultimoProcessado;
        }
    }
}