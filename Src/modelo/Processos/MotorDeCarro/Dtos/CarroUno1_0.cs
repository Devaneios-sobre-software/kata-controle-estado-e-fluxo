namespace modelo.Processos.MotorDeCarro.Dtos
{
    public record CarroUno1_0 : IDadoDto, IPossuiMotor
    {
        public string Nome { get; init; }
        public string Marca { get; init; }
        public short AnoFabricacao { get; init; }
        public IDadoDto Motor { get; set; }

        public void AdicionarMotor(IDadoDto motor)
        {
            this.Motor = motor;
        }
    }
}