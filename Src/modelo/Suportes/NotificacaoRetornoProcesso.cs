using System.Collections;
using System.Collections.Generic;

namespace modelo.Suportes
{
    public sealed class NotificacaoRetornoProcesso : INotificacao
    {
        IList<string> _notificacoes;

        public NotificacaoRetornoProcesso()
        {
            _notificacoes = new List<string>();
        }
        public INotificacao Adicionar(string mensagem)
        {
            if (!string.IsNullOrWhiteSpace(mensagem))
                this._notificacoes.Add(mensagem);

            return this;
        }

        public IEnumerable Obter()
        {
            return this._notificacoes;
        }
    }
}