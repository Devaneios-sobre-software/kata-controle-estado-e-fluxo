using modelo.Processos.Common;
using modelo.Processos.MotorDeCarro.Dtos;

namespace modelo.Processos.Mapeamento
{
    public sealed class ProcessoMapeamento : IProcessoMapeamentoDto
    {

        public ProcessoMapeamento()
        {

        }

        public IDadoBoxDto Executar(IDadoBoxDto entrada)
        {
            bool possuiMotor = entrada?.DadoDto is IPossuiMotor;

            if (possuiMotor)
            {
                ((IPossuiMotor)entrada.DadoDto).AdicionarMotor(new Motor { Marca = "Bosh" });

                return entrada;
            }


            return entrada;
        }
    }
}