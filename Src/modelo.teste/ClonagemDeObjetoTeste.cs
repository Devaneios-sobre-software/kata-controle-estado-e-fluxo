using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using modelo.Processos.Common;
using Xunit;

namespace modelo.teste
{
    public class ClonagemDeObjetoTeste
    {
        [Fact]
        public void TestName()
        {
            Objeto dado = new Objeto() { Adulto = 1, Idade = 22 };

            Objeto dado2 = new Objeto() { Adulto = 3, Idade = 33, teste = 6 };

            Objeto dado3 = new Objeto() { };



            var ddddd = Conversor.CriaNovoDadoDto(dado2, (p) => dado, p => new { p.Adulto, p.Idade });

            dado2.Adulto = 0;

            Assert.True(dado == dado2);
        }

        [Fact]
        public void DeveCriarInstanciaDeObjetoNovoReplicandoSeusDados()
        {
            Objeto dado = new Objeto() { Adulto = 1, Idade = 22, Dado = new Objeto { Adulto = 73 } };

            Objeto dado2 = new Objeto() { Adulto = 3, Idade = 33, teste = 6 };

            var res = (Objeto)dado.CriarObjeto3();
            dado.Adulto = 55;
            dado2.Adulto = 99;
            dado.Dado.Adulto = 66;

            Assert.False(res.Adulto == dado.Adulto && res.Dado.Adulto == dado.Dado.Adulto);
        }
    }

    public interface IObjeto { }

    public class Objeto : IObjeto
    {
        public int teste = 0;
        public sbyte Adulto { get; set; } = 0;
        public int Idade { get; set; } = 0;
        public Objeto Dado { get; set; }
        public sbyte Privado { get; private set; }

        public sbyte Leitura { get; }

        public Objeto()
        {
            Privado = 17;
            Leitura = 18;
        }

    }

    public static class Teste2
    {
        //criar um novo objeto baseado no objeto passado por parametro

        public static void CriarObjeto(this Objeto d, Expression<Func<Objeto>> s, Action<Objeto> p)
        {
            p.Invoke(d);
        }

        public static Objeto CriarObjeto2(this Objeto d, Expression<Func<Objeto, Objeto>> p)
        {
            return p.Compile().Invoke(d);
        }

        private static object Criar(object d)
        {
            var t = d.GetType().Name;
            var n = d.GetType()
                .GetConstructor(
                    BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.Public | BindingFlags.OptionalParamBinding | BindingFlags.NonPublic,
                    null, CallingConventions.Any, new Type[] { }, null
                )
                .Invoke(null);

            var dprops = d.GetType().GetProperties().Where(w => w.GetSetMethod() != null);
            var nprops = n.GetType().GetProperties().Where(w => w.GetSetMethod() != null);

            foreach (var prop in dprops)
            {
                var dv = prop.GetValue(d);

                if (dv == null)
                    continue;

                var nprop = nprops.FirstOrDefault(p => p.Name == prop.Name && p.GetType() == prop.GetType());

                var primitivo = dv.GetType().IsPrimitive;

                if (!primitivo)
                {
                    nprop.SetValue(n, Criar(dv));
                }

                if (primitivo && nprop != null)
                    nprop.SetValue(n, dv);

            }

            return n;
        }

        public static IObjeto CriarObjeto3(this IObjeto d)
        {
            return (IObjeto)Criar(d);
        }
    }
}
namespace modelo.teste
{

    public static class Conversor
    {
        public static Objeto CriaNovoDadoDto(Objeto bas, Expression<Func<Objeto, Objeto>> substituir, Expression<Func<Objeto, object>> selecao)
        {
            Objeto novo = new Objeto();

            var nnn = selecao.Compile().Invoke(substituir.Compile().Invoke(novo));

            var propsNovo = novo.GetType().GetProperties();
            var alterar = nnn.GetType().GetProperties();

            foreach (var item in propsNovo)
            {
                var valorVelho = item.GetValue(novo);

                var propriedadeBase = alterar.FirstOrDefault(x => x.Name == item.Name && x.PropertyType == item.PropertyType);

                var valorNovo = propriedadeBase?.GetValue(nnn);

                var nnp = propsNovo.FirstOrDefault(x => x.Name == item.Name && x.PropertyType == item.PropertyType);

                if (valorNovo != null && valorNovo != valorVelho)
                {
                    nnp?.SetValue(novo, valorNovo);
                }
                else
                {
                    nnp?.SetValue(novo, valorVelho);
                }
            }

            return novo;
        }
    }
}