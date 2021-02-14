namespace modelo.Processos.Common
{
    public sealed class DadoDto : IDadoDto
    {
        string _dado;


        public DadoDto(string dado, int casa = 0)
        {
            this._dado = dado;
        }

        public override string ToString()
        {
            return this._dado;
        }

        public static implicit operator string(DadoDto d)
        {
            return d.ToString();
        }

        public static implicit operator DadoDto(string d)
        {
            return new DadoDto(d);
        }
    }
}