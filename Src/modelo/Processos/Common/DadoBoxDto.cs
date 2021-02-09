using System;
using System.Collections;

namespace modelo.Processos
{
    public sealed class DadoBoxDto : IDadoBoxDto
    {
        public IEnumerable Notificacoes { get; }

        public IDadoDto DadoDto { get; }


        public DadoBoxDto(IDadoDto dado)
        {
            this.DadoDto = dado;
        }

        public IEnumerable AdicionarNotificacao(string notificacao)
        {
            throw new System.NotImplementedException();
        }
    }
}