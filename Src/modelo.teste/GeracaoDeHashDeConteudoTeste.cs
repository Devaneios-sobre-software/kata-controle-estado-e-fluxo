using modelo.Processos.Common;
using Xunit;

namespace modelo.teste
{
    public class GeracaoDeHashDeConteudoTeste
    {
        [Fact]
        public void TestName()
        {
            var dado1 = new DadoImutavelDto("felipe");
            dado1.Lista.Add("dado1");
            var hash1 = dado1.GetHashCode();

            var dado2 = new DadoImutavelDto("felipe");

            var hash2 = dado2.GetHashCode();

            var dado3 = dado1;
            dado3.MyProperty = 2;

            var hash3 = dado3.GetHashCode();

            var dado4 = dado3.Clonar();
            dado4.MyProperty = 4;
            dado4.Lista.Add("dado4");

            var hash4 = dado4.GetHashCode();

            Assert.False(hash1 is 0 or 2);
        }
    }
}