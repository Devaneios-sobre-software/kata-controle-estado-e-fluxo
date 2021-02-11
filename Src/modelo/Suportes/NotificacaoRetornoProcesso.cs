using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace modelo.Suportes
{
    public sealed class NotificacaoRetornoProcesso : INotificacao
    {
        IList<string> notificacoes;

        public NotificacaoRetornoProcesso()
        {
            notificacoes = new List<string>();
        }
        public INotificacao Adicionar(string mensagem)
        {
            if (!string.IsNullOrWhiteSpace(mensagem))
                this.notificacoes.Add(mensagem);

            return this;
        }

        public IEnumerable Obter()
        {
            return this.notificacoes;
        }
    }
}