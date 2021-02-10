using System;
using System.Collections;
using modelo.Suportes;

namespace modelo.Processos
{
    public interface IDadoBoxDto
    {
        INotificacao Notificador { get; }
        IDadoDto DadoDto { get; }
    }
}