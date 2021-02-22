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

        [Fact]
        public void DeveClonarObjetoStringPorValor()
        {
            //TODO ajustar problema da lista , copiar por union ou implementar um leitor e registrador de dados de arrays - esta dando erro dos parametros

            IDadoBoxDto dado = new DadoBoxDto(new DadoImutavelDto("Pedro"));
            dado.Notificador.Adicionar("11111");
            var d = (DadoImutavelDto)dado.DadoDto;

            var res = (DadoBoxDto)dado.ClonarObjeto();
            res.Notificador.Adicionar("aaaaa");

            var dd = (DadoImutavelDto)res.DadoDto;
            res.addDado(new DadoImutavelDto("Monica"));

            dado.Notificador.Adicionar("3333333");


            Assert.False(false == true);
        }
    }
}