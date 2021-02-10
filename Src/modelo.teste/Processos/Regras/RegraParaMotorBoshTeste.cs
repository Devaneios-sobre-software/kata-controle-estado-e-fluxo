using System;
using System.Collections.Generic;
using modelo.Processos;
using modelo.Processos.MotorDeCarro;
using modelo.Processos.MotorDeCarro.Dtos;
using modelo.Processos.Validacao;
using Xunit;

namespace modelo.teste.Processos.Regras
{
    public class RegraParaMotorBoshTeste
    {
        [Fact]
        public void DeveNegarCasoMotorNaoSejaBosh()
        {
            IList<(string msg, Func<IPossuiMotor, bool> regra)> regras = new List<(string msg, Func<IPossuiMotor, bool> regra)>
            {
                (msg: "Entrada nao possui motor Bosh", regra: (p) => p.Motor == null)
            };

            Assert.True(regras[0].regra.Invoke(new CarroUno1_0 { Nome = "Uno", AnoFabricacao = 2020 }));
        }
    }
}