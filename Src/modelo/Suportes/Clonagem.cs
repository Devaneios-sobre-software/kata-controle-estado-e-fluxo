using System;
using System.Linq;
using System.Reflection;
using modelo.Processos.Common;

namespace modelo.Suportes
{
    public static class Clonagem
    {
        private static object Clonar(object d)
        {
            if (d == null)
                return null;

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

                if (!primitivo && dv.GetType().GetInterfaces().Any(aa => aa.Name == typeof(IDadoDto).Name))
                {
                    nprop.SetValue(n, Clonar(dv));
                    continue;
                }

                nprop.SetValue(n, dv);

            }

            return n;
        }

        public static IDadoBoxDto ClonarObjeto(this IDadoBoxDto d)
        {
            return (IDadoBoxDto)Clonar(d);
        }
    }
}