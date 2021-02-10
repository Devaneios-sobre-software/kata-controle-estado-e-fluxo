namespace modelo.Processos.MotorDeCarro.Dtos
{
    public interface IPossuiMotor : IDadoDto
    {
        IDadoDto Motor { get; set; }

        void AdicionarMotor(IDadoDto motor);
    }
}