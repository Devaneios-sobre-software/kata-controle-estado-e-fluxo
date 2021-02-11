namespace modelo.Processos.Common
{
    public interface IProcesso
    {
        IDadoBoxDto Executar(IDadoBoxDto entrada);
    }
}