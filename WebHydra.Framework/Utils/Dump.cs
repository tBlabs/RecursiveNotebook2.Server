using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebHydra.Framework.Utils
{
    public static class Dump
    {
        public static string Props(object obj)
        {
            string o = Environment.NewLine + obj.GetType().Name + ": ";

            foreach (PropertyInfo p in obj.GetType().GetProperties())
            {
                var val = p.GetValue(obj) != null ? p.GetValue(obj) : "null";

                o += $"{Environment.NewLine}  {p.Name}: {p.PropertyType.Name} = {val},";
            }

            return o.TrimEnd(' ', ',');
        }
    }
}
