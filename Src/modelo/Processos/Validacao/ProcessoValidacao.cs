using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using modelo.Processos.MotorDeCarro.Dtos;

namespace modelo.Processos.Validacao
{
    public class ProcessoValidacao : IProcessoValidacao
    {
        IList<(string msg, Expression<Func<IDadoDto, bool>> regra)> regras;
        public ProcessoValidacao(IList<(string msg, Expression<Func<IDadoDto, bool>> regra)> regras)
        {
            this.regras = regras;
        }
        public ProcessoValidacao()
        {

        }
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            foreach (var regra in regras)
            {
                var r = regra.regra.Compile();
                if (r.Invoke(entrada.DadoDto))
                {
                    entrada.Notificador.Adicionar(regra.msg);
                }
                else
                {
                    entrada.Notificador.Adicionar($"Problema ao executar regra com mensagem: '{regra.regra.Body.ToString()}'");
                }
            }

            return entrada;
        }
    }
}