using modelo.Suportes;
using Xunit;

namespace modelo.teste
{
    public class NotificacoesTeste
    {
        [Fact]
        public void DeveAdicionarNotificacaoComMensagemEmFormaDeString()
        {
            var notificacoes = new NotificacaoRetornoProcesso();
            notificacoes.Adicionar("notificacao");

            var enu = notificacoes.Obter().GetEnumerator();
            enu.MoveNext();

            Assert.True(enu.Current?.ToString() == "notificacao");
        }
    }
}