using System;
using modelo.Processos.MotorDeCarro.Dtos;

namespace modelo.Processos.Validacao
{
    public class ProcessoValidacao : IProcessoValidacao
    {
        (string msg, Func<IPossuiMotor, bool> regra) regra;
        public ProcessoValidacao((string msg, Func<IPossuiMotor, bool> regra) regra)
        {
            this.regra = regra;
        }
        public ProcessoValidacao()
        {

        }
        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {

            var a = (IPossuiMotor)entrada.DadoDto;
            var res = regra.regra?.Invoke(a) ?? false;

            if (res)
            {
                entrada.Notificador.Adicionar(regra.msg);
            }

            return entrada;
        }
    }
}