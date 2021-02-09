using System.Collections;

namespace modelo.Suportes
{
    public interface INotificacao
    {
        INotificacao Adicionar(string mensagem);

        IEnumerable Obter();
    }
}