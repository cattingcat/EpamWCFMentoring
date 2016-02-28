using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServiceHost
{
    static class Extensions
    {
        public static string AsStringOf<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, string> func)
        {
            return String.Join(",", enumerable.Select(func));
        }
    }
}
