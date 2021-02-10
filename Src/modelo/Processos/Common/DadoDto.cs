using modelo.Processos.MotorDeCarro.Dtos;

namespace modelo.Processos
{
    public sealed class DadoDto : IDadoDto
    {
        string dado;

        public DadoDto(string dado)
        {
            this.dado = dado;
        }

        public override string ToString()
        {
            return this.dado;
        }
    }
}