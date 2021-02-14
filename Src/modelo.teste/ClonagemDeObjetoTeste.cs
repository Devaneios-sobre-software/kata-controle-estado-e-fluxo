using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using modelo.Processos.Common;
using modelo.Suportes;
using Xunit;

namespace modelo.teste
{
    public class ClonagemDeObjetoTeste
    {
        [Fact]
        public void DeveClonarObjetoPorValor()
        {
            IDadoBoxDto dado = new DadoBoxDto(new DadoMutavelDto() { Nome = "Pedro", Idade = 22 });
            var d = (DadoMutavelDto)dado.DadoDto;

            var res = (IDadoBoxDto)dado.ClonarObjeto();

            var dn = (DadoMutavelDto)res.DadoDto;
            dn.Idade = 33;


            Assert.False(d.Idade == dn.Idade && d.Nome == dn.Nome);
        }
    }
}