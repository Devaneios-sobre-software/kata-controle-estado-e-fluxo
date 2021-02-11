using modelo.Suportes;

namespace modelo.Processos.Common
{
    public record DadoBoxDto : IDadoBoxDto
    {
        public IDadoDto DadoDto { get; init; }

        public INotificacao Notificador { get; }

        public DadoBoxDto()
        {
            Notificador = new NotificacaoRetornoProcesso();
        }

        public DadoBoxDto(IDadoDto dado) : this()
        {
            this.DadoDto = dado;
        }

    }
}