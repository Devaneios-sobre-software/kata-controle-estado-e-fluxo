namespace modelo.Processos
{
    public interface IProcesso
    {
        IDadoBoxDto Executar(IDadoBoxDto entrada);
    }
}