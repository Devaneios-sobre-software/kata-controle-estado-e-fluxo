namespace modelo.Processos.MotorDeCarro.Dtos
{
    public record Motor : IDadoDto
    {
        public string Marca { get; init; }
    }
}