using System;
using System.Collections;

namespace modelo.Processos
{
    public interface IDadoBoxDto
    {
        IEnumerable Notificacoes { get; }
        IDadoDto DadoDto { get; }

        IEnumerable AdicionarNotificacao(string notificacao);
    }
}