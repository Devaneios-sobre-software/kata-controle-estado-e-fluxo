using modelo.Suportes;

namespace modelo.Processos.Common
{
    public sealed class DadoBoxDto : IDadoBoxDto
    {
        public IDadoDto DadoDto { get; private set; }

        public INotificacao Notificador { get; private set; }

        public DadoBoxDto()
        {
            Notificador = new NotificacaoRetornoProcesso();
        }

        public DadoBoxDto(IDadoDto dado) : this()
        {
            this.DadoDto = dado;
        }


        public void addDado(IDadoDto d)
        {
            this.DadoDto = d;
        }

    }
}