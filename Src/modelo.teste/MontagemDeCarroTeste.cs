using modelo.Factory;
using modelo.Processos.Common;
using Xunit;

namespace modelo.teste
{
    public class MontagemDeCarroTeste
    {
        [Fact]
        public void DeveCriarCarroSimples()
        {
            var fabricaCarro = new CarroFactory()
                .Criar(new DadoBoxDto(new DadoDto("aluminio")));

            Assert.True(fabricaCarro.DadoDto?.ToString() == "aluminio");
        }
    }
}