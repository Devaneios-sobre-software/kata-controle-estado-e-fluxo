using modelo.Suportes;

namespace modelo.Processos.Common
{
    public interface IDadoBoxDto
    {
        INotificacao Notificador { get; }
        IDadoDto DadoDto { get; }
    }
}