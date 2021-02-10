using System;
using System.Collections.Generic;
using modelo.Processos.MotorDeCarro.Dtos;

namespace modelo.Processos.Validacao
{
    public class ProcessoValidacao : IProcessoValidacao
    {
        IList<(string msg, Func<IPossuiMotor, bool> regra)> regras;
        public ProcessoValidacao(IList<(string msg, Func<IPossuiMotor, bool> regra)> regras)
        {
            this.regras = regras;
        }
        public ProcessoValidacao()
        {

        }
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            var a = (IPossuiMotor)entrada.DadoDto;

            foreach (var regra in regras)
            {
                if (regra.regra.Invoke(a))
                {
                    entrada.Notificador.Adicionar(regra.msg);
                }
            }

            return entrada;
        }
    }
}