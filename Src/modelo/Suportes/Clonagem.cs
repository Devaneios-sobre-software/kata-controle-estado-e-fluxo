using System;
using System.Collections;
using System.Collections.Generic;
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

            var con = d.GetType()
                .GetConstructor(
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                    null, CallingConventions.Any, new Type[] { }, null
                );

            con = con ?? d.GetType()
                .GetConstructors().FirstOrDefault();

            var ps = con.GetParameters();

            var n = con.Invoke(ps.Select(s => default(object)).ToArray());

            var dmembros = d.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var nmembros = n.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);


            var tipos = new MemberTypes[] { MemberTypes.Property, MemberTypes.Field };

            var dprops = dmembros
                .Where(w => tipos.Contains(w.MemberType));

            var nprops = nmembros
                .Where(w => tipos.Contains(w.MemberType));

            foreach (var prop in dprops)
            {
                if (prop.MemberType == MemberTypes.Property)
                    ClonaPropriedades(prop, d, n, nprops);
                if (prop.MemberType == MemberTypes.Field)
                    ClonaCampos(prop, d, n, nprops);
            }

            return n;
        }

        private static void ClonaPropriedades(MemberInfo m, object d, object n, IEnumerable<MemberInfo> nprops)
        {
            if (m.MemberType == MemberTypes.Property)
            {
                PropertyInfo prop = (PropertyInfo)m;

                if (prop.SetMethod != null)
                {
                    var dv = prop.GetValue(d);

                    if (dv == null)
                        return;

                    PropertyInfo nprop = (PropertyInfo)nprops
                    .FirstOrDefault(p => p.MemberType == MemberTypes.Property && p.Name == prop.Name && p.GetType() == prop.GetType());

                    var primitivo = dv.GetType().IsPrimitive;

                    var tipos = new Type[] { typeof(IDadoDto), typeof(INotificacao) };

                    if (!primitivo && dv.GetType().GetInterfaces().Any(aa => tipos.Contains(aa)))
                    {
                        nprop.SetValue(n, Clonar(dv));
                        return;
                    }
                    nprop.SetValue(n, dv);
                }
            }
        }

        private static void ClonaCampos(MemberInfo m, object d, object n, IEnumerable<MemberInfo> nprops)
        {
            if (m.MemberType == MemberTypes.Field)
            {
                FieldInfo prop = (FieldInfo)m;


                var dv = prop.GetValue(d);

                if (dv == null)
                    return;

                FieldInfo nprop = (FieldInfo)nprops
                .FirstOrDefault(p => p.MemberType == MemberTypes.Field && p.Name == prop.Name && p.GetType() == prop.GetType());

                var primitivo = dv.GetType().IsPrimitive;

                var tipos = new Type[] { typeof(IDadoDto) };

                if (!primitivo && dv.GetType().GetInterfaces().Any(aa => tipos.Contains(aa)))
                {
                    nprop.SetValue(n, Clonar(dv));
                    return;
                }
                nprop.SetValue(n, dv);

            }
        }


        public static IDadoBoxDto ClonarObjeto(this IDadoBoxDto d)
        {
            return (IDadoBoxDto)Clonar(d);
        }
    }
}